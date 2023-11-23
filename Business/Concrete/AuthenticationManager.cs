using Business.Abstract;
using Business.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthenticationManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<AccessToken>> CreateToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByEmailAsync(userForLoginDto.Email);
            if(userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.EmailError);
            }

            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccess);
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            await _userService.AddAsync(user);
            return new SuccessDataResult<User>(user, Messages.RegisterSuccess);

        }

        public async Task<IResult> UserExist(string email)
        {
            if (await _userService.GetByEmailAsync(email) != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }


    }
}

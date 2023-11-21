using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(User user)
        {
            await _userDal.DeleteAsync(user);
            return  new SuccessResult();
        }

        public async Task<IDataResult<List<User>>> GetAllAsync()
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetAllAsync());
        }

        public async Task<IDataResult<User>> GetAsync(int id)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.Id == id));
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userDal.GetAsync(u => u.Email == email);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
            return new SuccessResult();
        }
    }
}

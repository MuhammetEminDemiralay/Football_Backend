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
             _userDal.AddAsync(user);
            return new SuccessResult();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userDal.GetAsync(u => u.Email == email);
        }
    }
}

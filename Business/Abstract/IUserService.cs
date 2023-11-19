using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<User> GetByEmailAsync(string email);
        Task<IResult> AddAsync(User user);
    }
}

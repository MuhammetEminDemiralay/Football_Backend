using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAllAsync();
        Task<IDataResult<User>> GetAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<IResult> AddAsync(User user);
        Task<IResult> DeleteAsync(User user);
        Task<IResult> UpdateAsync(User user);

    }
}

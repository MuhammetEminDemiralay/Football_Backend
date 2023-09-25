using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionService
    {
        Task<IDataResult<List<Position>>> GetAllAsync();
        Task<IDataResult<Position>> GetAsync(int id);
        Task<IResult> AddAsync(Position position);
        Task<IResult> UpdateAsync(Position position);
        Task<IResult> DeleteAsync(Position position);
    }
}

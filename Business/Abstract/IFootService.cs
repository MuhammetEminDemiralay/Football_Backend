using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootService
    {
        Task<IDataResult<List<Foot>>> GetAllAsync();
        Task<IDataResult<Foot>> GetAsync(int id);
        Task<IResult> AddAsync(Foot foot);
        Task<IResult> UpdateAsync(Foot foot);
        Task<IResult> DeleteAsync(Foot foot);
    }
}

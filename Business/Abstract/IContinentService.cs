using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContinentService
    {
        Task<IDataResult<List<Continent>>> GetAllAsync();
        Task<IDataResult<Continent>> GetAsync(int id);
        Task<IResult> AddAsync(Continent continent);
        Task<IResult> UpdateAsync(Continent continent);
        Task<IResult> DeleteAsync(Continent continent);
    }
}

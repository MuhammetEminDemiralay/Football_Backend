using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryService
    {
        Task<IDataResult<List<Country>>> GetAllAsync();
        Task<IDataResult<Country>> GetAsync(int id);
        Task<IResult> AddAsync(Country country);
        Task<IResult> UpdateAsync(Country country);
        Task<IResult> DeleteAsync(Country country);
    }
}

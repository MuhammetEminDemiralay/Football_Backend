using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IDataResult<List<City>>> GetAllAsync();
        Task<IDataResult<City>> GetAsync(int id);
        Task<IResult> AddAsync(City city);
        Task<IResult> UpdateAsync(City city);
        Task<IResult> DeleteAsync(City city);
        Task<IDataResult<List<City>>> GetCityByCountryIdAsync(int countryId);
    }
}

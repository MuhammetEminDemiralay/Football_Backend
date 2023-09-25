using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryImageService 
    {
        Task<IDataResult<List<CountryImage>>> GetAllAsync();
        Task<IDataResult<CountryImage>> GetImageByCountryIdAsync(int countryId);
        Task<IResult> AddAsync(IFormFile file, CountryImage carImage);
        Task<IResult> AddCollectiveAsync(IFormFile[] files, CountryImage carImage);
        Task<IResult> UpdateAsync(IFormFile file, CountryImage carImage);
        Task<IResult> DeleteAsync(CountryImage carImage);
    }
}

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
        IDataResult<List<CountryImage>> GetAll();
        IDataResult<CountryImage> GetImageByCountryId(int countryId);
        IResult Add(IFormFile file, CountryImage carImage);
        IResult AddCollective(IFormFile[] files, CountryImage carImage);
        IResult Update(IFormFile file, CountryImage carImage);
        IResult Delete(CountryImage carImage);
    }
}

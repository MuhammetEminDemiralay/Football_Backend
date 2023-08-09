using Business.Abstract;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountryImageManager : ICountryImageService
    {
        ICountryImageDal _countryImageDal;

        public CountryImageManager(ICountryImageDal countryImageDal)
        {
            _countryImageDal = countryImageDal;
        }

        public IResult Add(IFormFile file, CountryImage countryImage)
        {
            countryImage.CountryImagePath= FileHelper.Add(file);
            countryImage.Date = DateTime.Now;
            _countryImageDal.Add(countryImage);
            return new SuccessResult("Country image added");
        }

        public IResult AddCollective(IFormFile[] files, CountryImage countryImage)
        {
            foreach (var file in files)
            {
                countryImage= new CountryImage{ CountryId = countryImage.CountryId};
                Add(file, countryImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(CountryImage countryImage)
        {
            _countryImageDal.Delete(countryImage);
            return new SuccessResult("Country image delete");
        }

        public IDataResult<List<CountryImage>> GetAll()
        {
            return new SuccessDataResult<List<CountryImage>>(_countryImageDal.GetAll(), "Country images listed");
        }

        public IDataResult<CountryImage> GetImageByCountryId(int countryId)
        {
            return new SuccessDataResult<CountryImage>(_countryImageDal.Get(p => p.CountryId == countryId));
        }

        public IResult Update(IFormFile file, CountryImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}

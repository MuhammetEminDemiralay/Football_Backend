using Business.Abstract;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

        public async Task<IResult> AddAsync(IFormFile file, CountryImage countryImage)
        {
            countryImage.CountryImagePath= FileHelper.Add(file);
            countryImage.Date = DateTime.Now;
            await _countryImageDal.AddAsync(countryImage);
            return new SuccessResult("Country image added");
        }

        public async Task<IResult> AddCollectiveAsync(IFormFile[] files, CountryImage countryImage)
        {
            foreach (var file in files)
            {
                countryImage= new CountryImage{ CountryId = countryImage.CountryId};
                await AddAsync(file, countryImage);
            }
            return new SuccessResult("Oldu");
        }

        public async Task<IResult> DeleteAsync(CountryImage countryImage)
        {
            await _countryImageDal.AddAsync(countryImage);
            return new SuccessResult("Country image delete");
        }

        public async Task<IDataResult<List<CountryImage>>> GetAllAsync()
        {
            return new SuccessDataResult<List<CountryImage>>(await _countryImageDal.GetAllAsync(), "Country images listed");
        }

        public async Task<IDataResult<CountryImage>> GetImageByCountryIdAsync(int countryId)
        {
            return new SuccessDataResult<CountryImage>(await _countryImageDal.GetAsync(p => p.CountryId == countryId));
        }

        public async Task<IDataResult<CountryImage>> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<CountryImage>(await _countryImageDal.GetAsync(p => p.Id == imageId));
        }

        public async Task<IResult> UpdateAsync(IFormFile file, CountryImage countryImage)
        {
            CountryImage oldCountryImage = GetImageByImageId(countryImage.Id).Result.Data;
            countryImage.CountryImagePath= FileHelper.Update(file, oldCountryImage.CountryImagePath);
            countryImage.Date = DateTime.Now;
            countryImage.CountryId = oldCountryImage.CountryId;
            _countryImageDal.UpdateAsync(countryImage);
            return new SuccessResult("Country image updated");
        }
    }
}

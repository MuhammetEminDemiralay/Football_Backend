using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect;
using Core.CrossCuttingConcerns.Logging;
using Core.RequestFeatures;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Exceptions.Concrete;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        ILoggerService _logger;

        public CityManager(ICityDal cityDal, ILoggerService logger)
        {
            _cityDal = cityDal;
            _logger = logger;
        }

        [FluentValidationAspect(typeof(CityValidator))]
        public async Task<IResult> AddAsync(City city)
        {
            //var result = BusinessRules.Run(CheckIfCityNameExitst(city.CityName));
            //if(result != null)
            //{
            //    return result;
            //}

            await _cityDal.AddAsync(city);
            _logger.LogInfo($"Add {city.CityName} added");
            return new SuccessResult(Messages.CityAdd);
        }

        public async Task<IResult> DeleteAsync(City city)
        {
            await _cityDal.DeleteAsync(city);
            return new SuccessResult(Messages.CityDelete);
        }

        public async Task<IDataResult<City>> GetAsync(int id)
        {
            return new SuccessDataResult<City>(await _cityDal.GetAsync(p => p.Id == id), Messages.CityGet);
        }

        public async Task<IDataResult<List<City>>> GetAllAsync()
        {
            return new SuccessDataResult<List<City>>(await _cityDal.GetAllAsync(), Messages.CityList);
        }

        public async Task<IDataResult<List<City>>> GetCityByCountryIdAsync(int countryId)
        {
            return new SuccessDataResult<List<City>>(await _cityDal.GetAllAsync(p => p.CountryId == countryId), "Country ıd ye göre city ler listelendi");
        }

        public async Task<IResult> UpdateAsync(City city)
        {
            await _cityDal.UpdateAsync(city);
            return new SuccessResult(Messages.CityUpdate);
        }

        public async Task<(IEnumerable<City> city, MetaData metaData)> GetAllPaginationCity(CityParameters parameters)
        {
            var result =  await _cityDal.GetAllTryCity(parameters);
            return (result, result.MetaData);
        }


        // Business Rules

        //private async Task<IResult> CheckIfCityNameExitst(string cityName)
        //{
        //    var result =  _cityDal.GetAllAsync(p => p.CityName == cityName).AnyAsync();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.AlreadyCityName);
        //    }
        //    return new SuccessResult();
        //}

    }
}

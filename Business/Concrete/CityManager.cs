using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [FluentValidationAspect(typeof(CityValidator))]
        public IResult Add(City city)
        {
            var result = BusinessRules.Run(CheckIfCityNameExitst(city.CityName));
            if(result != null)
            {
                return result;
            }

            _cityDal.Add(city);
            return new SuccessResult(Messages.CityAdd);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.CityDelete);
        }

        public IDataResult<City> Get(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(p => p.Id == id), Messages.CityGet);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), Messages.CityList);
        }

        public IDataResult<List<City>> GetCityByCountryId(int countryId)
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(p => p.CountryId == countryId), "Country ıd ye göre city ler listelendi");
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.CityUpdate);
        }


        // Business Rules

        private IResult CheckIfCityNameExitst(string cityName)
        {
            var result = _cityDal.GetAll(p => p.CityName == cityName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyCityName);
            }
            return new SuccessResult();
        }

    }
}

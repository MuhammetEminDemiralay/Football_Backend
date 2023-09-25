using Business.Abstract;
using Business.Constant;
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
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<IResult> AddAsync(Country country)
        {
            await _countryDal.AddAsync(country);
            return new SuccessResult(Messages.CountryAdd);
        }

        public async Task<IResult> DeleteAsync(Country country)
        {
            await _countryDal.DeleteAsync(country);
            return new SuccessResult(Messages.CountryDelete);
        }

        public async Task<IDataResult<Country>> GetAsync(int id)
        {
            return new SuccessDataResult<Country>(await _countryDal.GetAsync(p => p.Id == id), Messages.CountryGet);
        }

        public async Task<IDataResult<List<Country>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Country>>(await _countryDal.GetAllAsync(), Messages.CountryList);
        }

        public async Task<IResult> UpdateAsync(Country country)
        {
            await _countryDal.UpdateAsync(country);
            return new SuccessResult(Messages.CountryUpdate);
        }
    }
}

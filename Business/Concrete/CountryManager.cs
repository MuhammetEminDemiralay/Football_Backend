using Business.Abstract;
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

        public IResult Add(Country country)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Country country)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Country> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Country>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}

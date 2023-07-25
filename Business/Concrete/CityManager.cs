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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public IResult Add(City city)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(City city)
        {
            throw new NotImplementedException();
        }

        public IDataResult<City> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<City>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class ContinentManager : IContinentService
    {
        IContinentDal _continentDal;

        public ContinentManager(IContinentDal continentDal)
        {
            _continentDal = continentDal;
        }

        public IResult Add(Continent continent)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Continent continent)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Continent> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Continent>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Continent continent)
        {
            throw new NotImplementedException();
        }
    }
}

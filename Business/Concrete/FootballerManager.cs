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
    public class FootballerManager : IFootballerService
    {
        IFootballerDal _footballerDal;

        public FootballerManager(IFootballerDal footballerDal)
        {
            _footballerDal = footballerDal;
        }

        public IResult Add(Footballer footballer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Footballer footballer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Footballer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Footballer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Footballer footballer)
        {
            throw new NotImplementedException();
        }
    }
}

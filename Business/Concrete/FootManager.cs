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
    public class FootManager : IFootService
    {

        IFootDal _footDal;

        public FootManager(IFootDal footDal)
        {
            _footDal = footDal;
        }

        public IResult Add(Foot foot)
        {
            _footDal.Add(foot);
            return new SuccessResult();
        }

        public IResult Delete(Foot foot)
        {
            _footDal.Delete(foot);
            return new SuccessResult();
        }

        public IDataResult<Foot> Get(int id)
        {
            return new SuccessDataResult<Foot>(_footDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Foot>> GetAll()
        {
            return new SuccessDataResult<List<Foot>>(_footDal.GetAll());
        }

        public IResult Update(Foot foot)
        {
            _footDal.Update(foot);
            return new SuccessResult();
        }
    }
}

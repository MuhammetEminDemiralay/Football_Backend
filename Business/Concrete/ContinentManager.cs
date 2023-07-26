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
    public class ContinentManager : IContinentService
    {
        IContinentDal _continentDal;

        public ContinentManager(IContinentDal continentDal)
        {
            _continentDal = continentDal;
        }

        public IResult Add(Continent continent)
        {
            _continentDal.Add(continent);
            return new SuccessResult(Messages.ContinentAdd);
        }

        public IResult Delete(Continent continent)
        {
            _continentDal.Delete(continent);
            return new SuccessResult(Messages.ContinentDelete);
        }

        public IDataResult<Continent> Get(int id)
        {
            return new SuccessDataResult<Continent>(_continentDal.Get(p => p.Id == id), Messages.ContinentGet);
        }

        public IDataResult<List<Continent>> GetAll()
        {
            return new SuccessDataResult<List<Continent>>(_continentDal.GetAll(), Messages.ContinentList);
        }

        public IResult Update(Continent continent)
        {
            _continentDal.Update(continent);
            return new SuccessResult(Messages.ContinentUpdate);
        }
    }
}

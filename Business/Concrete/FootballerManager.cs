using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
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

        [FluentValidationAspect(typeof(FootballerValidator))]
        public IResult Add(Footballer footballer)
        {
            _footballerDal.Add(footballer);
            return new SuccessResult(Messages.FootballerAdd);
        }

        public IResult Delete(Footballer footballer)
        {
            _footballerDal.Delete(footballer);
            return new SuccessResult(Messages.FootballerDelete);
        }

        public IDataResult<Footballer> Get(int id)
        {
            return new SuccessDataResult<Footballer>(_footballerDal.Get(p => p.Id == id), Messages.FootballerGet);
        }

        public IDataResult<List<Footballer>> GetAll()
        {
            return new SuccessDataResult<List<Footballer>>(_footballerDal.GetAll(), Messages.FootballerList);
        }

        public IResult Update(Footballer footballer)
        {
            _footballerDal.Update(footballer);
            return new SuccessResult(Messages.FootballerUpdate);
        }
    }
}

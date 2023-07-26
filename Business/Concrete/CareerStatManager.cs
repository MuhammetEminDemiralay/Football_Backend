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
    public class CareerStatManager : ICareerStatService
    {
        ICareerStatDal _careerStatDal;

        public CareerStatManager(ICareerStatDal careerStatDal)
        {
            _careerStatDal = careerStatDal;
        }

        public IResult Add(CareerStat careerStat)
        {
            _careerStatDal.Add(careerStat);
            return new SuccessResult(Messages.CareerStatAdded);
        }

        public IResult Delete(CareerStat careerStat)
        {
            _careerStatDal.Delete(careerStat);
            return new SuccessResult(Messages.CareerStatDelete);
        }

        public IDataResult<CareerStat> Get(int id)
        {
            return new SuccessDataResult<CareerStat>(_careerStatDal.Get(p => p.Id == id), Messages.CareerStatGet);
        }

        public IDataResult<List<CareerStat>> GetAll()
        {
            return new SuccessDataResult<List<CareerStat>>(_careerStatDal.GetAll(), Messages.CareerStatListed);
        }

        public IResult Update(CareerStat careerStat)
        {
            _careerStatDal.Update(careerStat);
            return new SuccessResult(Messages.CareerStatUpdate);
        }
    }
}

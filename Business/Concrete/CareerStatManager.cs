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

        public async Task<IResult> AddAsync(CareerStat careerStat)
        {
            await _careerStatDal.AddAsync(careerStat);
            return new SuccessResult(Messages.CareerStatAdded);
        }

        public async Task<IResult> DeleteAsync(CareerStat careerStat)
        {
            await _careerStatDal.DeleteAsync(careerStat);
            return new SuccessResult(Messages.CareerStatDelete);
        }

        public async  Task<IDataResult<CareerStat>> GetAsync(int id)
        {
            return new SuccessDataResult<CareerStat>(await _careerStatDal.GetAsync(p => p.Id == id), Messages.CareerStatGet);
        }

        public async Task<IDataResult<List<CareerStat>>> GetAllAsync()
        {
            return new SuccessDataResult<List<CareerStat>>(await _careerStatDal.GetAllAsync(), Messages.CareerStatListed);
        }

        public async Task<IResult> UpdateAsync(CareerStat careerStat)
        {
            await _careerStatDal.UpdateAsync(careerStat);
            return new SuccessResult(Messages.CareerStatUpdate);
        }
    }
}

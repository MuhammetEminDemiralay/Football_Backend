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
    public class CareerStatManager : ICareerStatService
    {
        ICareerStatDal _careerStatDal;

        public CareerStatManager(ICareerStatDal careerStatDal)
        {
            _careerStatDal = careerStatDal;
        }

        public IResult Add(CareerStat careerStat)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CareerStat careerStat)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CareerStat> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CareerStat>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(CareerStat careerStat)
        {
            throw new NotImplementedException();
        }
    }
}

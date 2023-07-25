using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICareerStatService
    {
        IDataResult<List<CareerStat>> GetAll();
        IDataResult<CareerStat> Get(int id);
        IResult Add(CareerStat careerStat);
        IResult Update(CareerStat careerStat);
        IResult Delete(CareerStat careerStat);
    }
}

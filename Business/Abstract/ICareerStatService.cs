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
        Task<IDataResult<List<CareerStat>>> GetAllAsync();
        Task<IDataResult<CareerStat>> GetAsync(int id);
        Task<IResult> AddAsync(CareerStat careerStat);
        Task<IResult> UpdateAsync(CareerStat careerStat);
        Task<IResult> DeleteAsync(CareerStat careerStat);
    }
}

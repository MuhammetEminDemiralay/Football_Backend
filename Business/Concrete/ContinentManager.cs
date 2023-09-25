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

        public async Task<IResult> AddAsync(Continent continent)
        {
            await _continentDal.AddAsync(continent);
            return new SuccessResult(Messages.ContinentAdd);
        }

        public async Task<IResult> DeleteAsync(Continent continent)
        {
            await _continentDal.DeleteAsync(continent);
            return new SuccessResult(Messages.ContinentDelete);
        }

        public async Task<IDataResult<Continent>> GetAsync(int id)
        {
            return new SuccessDataResult<Continent>(await _continentDal.GetAsync(p => p.Id == id), Messages.ContinentGet);
        }

        public async Task<IDataResult<List<Continent>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Continent>>(await _continentDal.GetAllAsync(), Messages.ContinentList);
        }

        public async Task<IResult> UpdateAsync(Continent continent)
        {
            await _continentDal.DeleteAsync(continent);
            return new SuccessResult(Messages.ContinentUpdate);
        }
    }
}

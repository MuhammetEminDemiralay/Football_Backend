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

        public async Task<IResult> AddAsync(Foot foot)
        {
            await _footDal.AddAsync(foot);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Foot foot)
        {
            await _footDal.DeleteAsync(foot);
            return new SuccessResult();
        }

        public async Task<IDataResult<Foot>> GetAsync(int id)
        {
            return new SuccessDataResult<Foot>(await _footDal.GetAsync(p => p.Id == id));
        }

        public async Task<IDataResult<List<Foot>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Foot>>(await _footDal.GetAllAsync());
        }

        public async Task<IResult> UpdateAsync(Foot foot)
        {
            await _footDal.UpdateAsync(foot);
            return new SuccessResult();
        }
    }
}

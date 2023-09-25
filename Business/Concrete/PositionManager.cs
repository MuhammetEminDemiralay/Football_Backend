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
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }

        public async Task<IResult> AddAsync(Position position)
        {
            await _positionDal.AddAsync(position);
            return new SuccessResult(Messages.PositonAdd);
        }

        public async Task<IResult> DeleteAsync(Position position)
        {
            await _positionDal.DeleteAsync(position);
            return new SuccessResult(Messages.PositionDelete);
        }

        public async Task<IDataResult<Position>> GetAsync(int id)
        {
            return new SuccessDataResult<Position>(await _positionDal.GetAsync(p => p.Id == id), Messages.PositionGet);
        }

        public async Task<IDataResult<List<Position>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Position>>(await _positionDal.GetAllAsync(), Messages.PositionList);
        }

        public async Task<IResult> UpdateAsync(Position position)
        {
            await _positionDal.UpdateAsync(position);
            return new SuccessResult(Messages.PositionUpdate);
        }
    }
}

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

        public IResult Add(Position position)
        {
            _positionDal.Add(position);
            return new SuccessResult(Messages.PositonAdd);
        }

        public IResult Delete(Position position)
        {
            _positionDal.Delete(position);
            return new SuccessResult(Messages.PositionDelete);
        }

        public IDataResult<Position> Get(int id)
        {
            return new SuccessDataResult<Position>(_positionDal.Get(p => p.Id == id), Messages.PositionGet);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(), Messages.PositionList);
        }

        public IResult Update(Position position)
        {
            _positionDal.Update(position);
            return new SuccessResult(Messages.PositionUpdate);
        }
    }
}

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
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }

        public IResult Add(Position position)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Position position)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Position> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Position>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Position position)
        {
            throw new NotImplementedException();
        }
    }
}

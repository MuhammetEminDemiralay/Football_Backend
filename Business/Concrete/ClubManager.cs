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
    public class ClubManager : IClubService
    {
        IClubDal _clubDal;

        public ClubManager(IClubDal clubDal)
        {
            _clubDal = clubDal;
        }

        public IResult Add(Club club)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Club club)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Club> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Club>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Club club)
        {
            throw new NotImplementedException();
        }
    }
}

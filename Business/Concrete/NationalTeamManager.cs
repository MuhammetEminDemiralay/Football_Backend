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
    public class NationalTeamManager : INationalTeamService
    {
        INationalTeamDal _nationalTeamDal;

        public NationalTeamManager(INationalTeamDal nationalTeamDal)
        {
            _nationalTeamDal = nationalTeamDal;
        }

        public IResult Add(NationalTeam nationalTeam)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(NationalTeam nationalTeam)
        {
            throw new NotImplementedException();
        }

        public IDataResult<NationalTeam> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<NationalTeam>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(NationalTeam nationalTeam)
        {
            throw new NotImplementedException();
        }
    }
}

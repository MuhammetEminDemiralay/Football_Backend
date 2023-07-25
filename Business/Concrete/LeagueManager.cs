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
    public class LeagueManager : ILeagueService
    {
        ILeagueDal _leagueDal;

        public LeagueManager(ILeagueDal leagueDal)
        {
            _leagueDal = leagueDal;
        }

        public IResult Add(League league)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(League league)
        {
            throw new NotImplementedException();
        }

        public IDataResult<League> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<League>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(League league)
        {
            throw new NotImplementedException();
        }
    }
}

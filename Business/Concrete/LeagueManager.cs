using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
            _leagueDal.Add(league);
            return new SuccessResult(Messages.LeagueaAdd);
        }

        public IResult Delete(League league)
        {
            _leagueDal.Delete(league);
            return new SuccessResult(Messages.LeagueDelete);
        }

        public IDataResult<League> Get(int id)
        {
            return new SuccessDataResult<League>(_leagueDal.Get(p => p.Id == id), Messages.LeagueGet);
        }

        public IDataResult<List<League>> GetAll()
        {
            return new SuccessDataResult<List<League>>(_leagueDal.GetAll(), Messages.LeagueList);
        }


        public IDataResult<List<LeagueDetailDto>> GetLeaguesbyCountryId(int countryId)
        {
            return new SuccessDataResult<List<LeagueDetailDto>>(_leagueDal.GetLeagueDetailDtos(p => p.CountryId == countryId), Messages.GetByCountryId);
        }

        public IResult Update(League league)
        {
            _leagueDal.Update(league);
            return new SuccessResult(Messages.LeagueUpdate);
        }
    }
}

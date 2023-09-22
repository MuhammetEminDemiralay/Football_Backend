using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(CheckIfLeagueNameExist(league.LeagueName));
            if (result != null)
            {
                return result;
            }
            _leagueDal.Add(league);
            return new SuccessResult(Messages.LeagueaAdd);
        }


        public IResult Delete(League league)
        {
            _leagueDal.Delete(league);
            return new SuccessResult(Messages.LeagueDelete);
        }

        public IDataResult<LeagueDetailDto> GetLegaueDetailByLeagueId(int leagueId)
        {
            return new SuccessDataResult<LeagueDetailDto>(_leagueDal.GetLeagueDetailByLeagueId(p => p.Id == leagueId), "lig ıd' ye göre lig detayları listelendi");
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
            IResult result = BusinessRules.Run(CheckIfLeagueNameExist(league.LeagueName));
            if(result != null)
            {
                return new ErrorResult(Messages.AlreadyLeagueName);
            }
            _leagueDal.Update(league);
            return new SuccessResult(Messages.LeagueUpdate);
        }



        // Business Rules
        private IResult CheckIfLeagueNameExist(string leagueName)
        {
            var result = _leagueDal.GetAll(p => p.LeagueName == leagueName).Any();

            if (result)
            {
                return new ErrorResult(Messages.AlreadyLeagueName);
            }

            return new SuccessResult();
        }

    }
}

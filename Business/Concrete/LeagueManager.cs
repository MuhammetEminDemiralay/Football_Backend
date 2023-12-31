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

        public async Task<IResult> AddAsync(League league)
        {
            //IResult result = BusinessRules.Run(CheckIfLeagueNameExist(league.LeagueName));
            //if (result != null)
            //{
            //    return result;
            //}
            await _leagueDal.AddAsync(league);
            return new SuccessResult(Messages.LeagueaAdd);
        }


        public async Task<IResult> DeleteAsync(League league)
        {
            await _leagueDal.DeleteAsync(league);
            return new SuccessResult(Messages.LeagueDelete);
        }

        public async Task<IDataResult<LeagueDetailDto>> GetLegaueDetailByLeagueIdAsync(int leagueId)
        {
            return new SuccessDataResult<LeagueDetailDto>(await _leagueDal.GetLeagueDetailByLeagueIdAsync(p => p.Id == leagueId), "lig ıd' ye göre lig detayları listelendi");
        }

        public async Task<IDataResult<List<League>>> GetAllAsync()
        {
            return new SuccessDataResult<List<League>>(await _leagueDal.GetAllAsync(), Messages.LeagueList);
        }


        public async Task<IDataResult<List<LeagueDetailDto>>> GetLeaguesbyCountryIdAsync(int countryId)
        {
            return new SuccessDataResult<List<LeagueDetailDto>>(await _leagueDal.GetLeagueDetailByCountryId(p => p.CountryId == countryId), Messages.GetByCountryId);
        }

        public async Task<IResult> UpdateAsync(League league)
        {
            //IResult result = BusinessRules.Run(CheckIfLeagueNameExist(league.LeagueName));
            //if(result != null)
            //{
            //    return new ErrorResult(Messages.AlreadyLeagueName);
            //}
            await _leagueDal.UpdateAsync(league);
            return new SuccessResult(Messages.LeagueUpdate);
        }



        // Business Rules
        //private IResult CheckIfLeagueNameExist(string leagueName)
        //{
        //    var result = _leagueDal.GetAll(p => p.LeagueName == leagueName).Any();

        //    if (result)
        //    {
        //        return new ErrorResult(Messages.AlreadyLeagueName);
        //    }

        //    return new SuccessResult();
        //}

    }
}

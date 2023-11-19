using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect;
using Core.RequestFeatures;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Exceptions.Concrete;
using Entities.RequestFeatures;
using NHibernate.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class FootballerManager : IFootballerService
    {
        IFootballerDal _footballerDal;

        public FootballerManager(IFootballerDal footballerDal)
        {
            _footballerDal = footballerDal;
        }

        public async Task<IResult> AddAsync(Footballer footballer)
        {
            await _footballerDal.AddAsync(footballer);
            return new SuccessResult(Messages.FootballerAdd);
        }

        public async Task<IResult> DeleteAsync(Footballer footballer)
        {
            await _footballerDal.DeleteAsync(footballer);
            return new SuccessResult(Messages.FootballerDelete);
        }

        public async Task<IDataResult<Footballer>> GetAsync(int id)
        {
            return new SuccessDataResult<Footballer>(await _footballerDal.GetAsync(p => p.Id == id), Messages.FootballerGet);
        }

        public async Task<IDataResult<List<Footballer>>> GetAllAsync(int minAge, int maxAge)
        {
            return new SuccessDataResult<List<Footballer>>(await _footballerDal.GetAllAsync(p => p.Age > minAge && p.Age < maxAge), Messages.FootballerList);
        }

        public async Task<IDataResult<List<FootballerDetailDto>>> GetFootballerDetailByCountryIdAsync(int countryId, bool nationalTeam, int nationalTeamLevel)
        {
            return new SuccessDataResult<List<FootballerDetailDto>>(await _footballerDal.GetFootballersDetailByCountryIdAsync(p => p.CountryId == countryId && p.NationalTeamPlayerActive == nationalTeam && p.NationalTeamLevel == nationalTeamLevel));
        }

        public async Task<IDataResult<FootballerDetailDto>> GetFootballerDetailByFootballerIdAsync(int footballerId)
        {
            return new SuccessDataResult<FootballerDetailDto>(await _footballerDal.GetFootballerDetailByFootballerIdAsync(p => p.Id == footballerId), "Futbolcu ıd sine göre futbolcu detayları getirildi");
        }

        public async Task<IDataResult<List<Footballer>>> GetFootballersByClubIdAsync(int clubId)
        {
            return new SuccessDataResult<List<Footballer>>(await _footballerDal.GetAllAsync(p => p.ClubId == clubId));
        }

        public async Task<IDataResult<List<FootballerDetailDto>>> GetFootballersDetailByClubIdAsync(int clubId)
        {
            return new SuccessDataResult<List<FootballerDetailDto>>(await _footballerDal.GetFootballersDetailByClubIdAsync(p => p.ClubId == clubId), "Club ıd ye göre futbolcuların detayları getirilidi");
        }

        public async Task<IResult> UpdateAsync(Footballer footballer)
        {
            await _footballerDal.UpdateAsync(footballer);
            return new SuccessResult(Messages.FootballerUpdate);
        }

        public async Task<(IEnumerable<Footballer> footballer, MetaData metaData)> GetAllPaginationFootballer(FootballerParameters parameters)
        {
            if (!parameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();
            var result = await _footballerDal.GetAllTryFootballer(parameters);
            return (result, result.MetaData);
        }
    }
}

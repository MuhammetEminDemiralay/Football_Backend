using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect;
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
    public class FootballerManager : IFootballerService
    {
        IFootballerDal _footballerDal;

        public FootballerManager(IFootballerDal footballerDal)
        {
            _footballerDal = footballerDal;
        }

        public IResult Add(Footballer footballer)
        {
            _footballerDal.Add(footballer);
            return new SuccessResult(Messages.FootballerAdd);
        }

        public IResult Delete(Footballer footballer)
        {
            _footballerDal.Delete(footballer);
            return new SuccessResult(Messages.FootballerDelete);
        }

        public IDataResult<Footballer> Get(int id)
        {
            return new SuccessDataResult<Footballer>(_footballerDal.Get(p => p.Id == id), Messages.FootballerGet);
        }

        public IDataResult<List<Footballer>> GetAll()
        {
            return new SuccessDataResult<List<Footballer>>(_footballerDal.GetAll(), Messages.FootballerList);
        }

        public IDataResult<List<FootballerDetailDto>> GetFootballerDetailByCountryId(int countryId, bool nationalTeam)
        {
            return new SuccessDataResult<List<FootballerDetailDto>>(_footballerDal.GetFootballersDetailByCountryId(p => p.CountryId == countryId && p.NationalTeamOnOff == nationalTeam));
        }

        public IDataResult<FootballerDetailDto> GetFootballerDetailByFootballerId(int footballerId)
        {
            return new SuccessDataResult<FootballerDetailDto>(_footballerDal.GetFootballerDetailByFootballerId(p => p.Id == footballerId), "Futbolcu ıd sine göre futbolcu detayları getirildi");
        }

        public IDataResult<List<Footballer>> GetFootballersByClubId(int clubId)
        {
            return new SuccessDataResult<List<Footballer>>(_footballerDal.GetAll(p => p.ClubId == clubId));
        }

        public IDataResult<List<FootballerDetailDto>> GetFootballersDetailByClubId(int clubId)
        {
            return new SuccessDataResult<List<FootballerDetailDto>>(_footballerDal.GetFootballersDetailByClubId(p => p.ClubId == clubId), "Club ıd ye göre futbolcuların detayları getirilidi");
        }

        public IResult Update(Footballer footballer)
        {
            _footballerDal.Update(footballer);
            return new SuccessResult(Messages.FootballerUpdate);
        }
    }
}

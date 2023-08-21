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
    public class ClubManager : IClubService
    {
        IClubDal _clubDal;

        public ClubManager(IClubDal clubDal)
        {
            _clubDal = clubDal;
        }

        public IResult Add(Club club)
        {
            _clubDal.Add(club);
            return new SuccessResult(Messages.ClubAdd);
        }

        public IResult Delete(Club club)
        {
            _clubDal.Delete(club);
            return new SuccessResult(Messages.ClubDelete);
        }

        public IDataResult<Club> Get(int id)
        {
            return new SuccessDataResult<Club>(_clubDal.Get(p => p.Id == id), Messages.ClubGet);
        }

        public IDataResult<List<Club>> GetAll()
        {
            return new SuccessDataResult<List<Club>>(_clubDal.GetAll(), Messages.ClubList);
        }

        public IDataResult<ClubDetailDto> GetClubDetailByClubId(int clubId)
        {
            return new SuccessDataResult<ClubDetailDto>(_clubDal.GetClubDetailByClubId(p => p.Id == clubId),"Club ıd ye göre club detayları getirildi");
        }

        public IDataResult<List<ClubDetailDto>> GetClubsDetailByLeagueId(int leagueId)
        {
            return new SuccessDataResult<List<ClubDetailDto>>(_clubDal.GetClubDetailDto(p => p.LeagueId == leagueId), Messages.GetByClubsLeagueId);
        }

        public IResult Update(Club club)
        {
            _clubDal.Update(club);
            return new SuccessResult(Messages.ClubUpdate);
        }
    }
}

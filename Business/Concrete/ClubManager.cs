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

        public async Task<IResult> AddAsync(Club club)
        {
            await _clubDal.AddAsync(club);
            return new SuccessResult(Messages.ClubAdd);
        }

        public async Task<IResult> DeleteAsync(Club club)
        {
            await _clubDal.DeleteAsync(club);
            return new SuccessResult(Messages.ClubDelete);
        }

        public async Task<IDataResult<Club>> GetAsync(int id)
        {
            return new SuccessDataResult<Club>(await _clubDal.GetAsync(p => p.Id == id), Messages.ClubGet);
        }

        public async Task<IDataResult<List<Club>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Club>>(await _clubDal.GetAllAsync(), Messages.ClubList);
        }

        public async Task<IDataResult<ClubDetailDto>> GetClubDetailByClubIdAsync(int clubId)
        {
            return new SuccessDataResult<ClubDetailDto>(await _clubDal.GetClubDetailByClubIdAsync(p => p.Id == clubId),"Club ıd ye göre club detayları getirildi");
        }

        public async Task<IDataResult<List<ClubDetailDto>>> GetClubsDetailByLeagueIdAsync(int leagueId)
        {
            return new SuccessDataResult<List<ClubDetailDto>>(await _clubDal.GetClubDetailAsync(p => p.LeagueId == leagueId), Messages.GetByClubsLeagueId);
        }

        public async Task<IResult> UpdateAsync(Club club)
        {
            await _clubDal.UpdateAsync(club);
            return new SuccessResult(Messages.ClubUpdate);
        }
    }
}

using Business.Abstract;
using Business.Constant;
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

        public IDataResult<List<Club>> GetClubsByLeagueId(int leagueId)
        {
            return new SuccessDataResult<List<Club>>(_clubDal.GetAll(p => p.LeagueId == leagueId), Messages.GetByClubsLeagueId);
        }

        public IResult Update(Club club)
        {
            _clubDal.Update(club);
            return new SuccessResult(Messages.ClubUpdate);
        }
    }
}

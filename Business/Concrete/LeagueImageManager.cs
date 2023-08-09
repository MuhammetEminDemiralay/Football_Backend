using Business.Abstract;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LeagueImageManager : ILeagueImageService
    {
        ILeagueImageDal _leagueImageDal;

        public LeagueImageManager(ILeagueImageDal leagueImageDal)
        {
            _leagueImageDal = leagueImageDal;
        }

        public IResult Add(IFormFile file, LeagueImage leagueImage)
        {
            leagueImage.LeagueImagePath= FileHelper.Add(file);
            leagueImage.Date = DateTime.Now;
            _leagueImageDal.Add(leagueImage);
            return new SuccessResult("Laegue image added");
        }

        public IResult AddCollective(IFormFile[] files, LeagueImage leagueImage)
        {
            foreach (var file in files)
            {
                leagueImage = new LeagueImage { LeagueId = leagueImage.LeagueId};
                Add(file, leagueImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(LeagueImage leagueImage)
        {
            _leagueImageDal.Delete(leagueImage);
            return new SuccessResult("league ımage delete");
        }

        public IDataResult<List<LeagueImage>> GetAll()
        {
            return new SuccessDataResult<List<LeagueImage>>(_leagueImageDal.GetAll(), "League image listed");
        }

        public IDataResult<LeagueImage> GetLeagueImageByLeagueId(int leagueId)
        {
            return new SuccessDataResult<LeagueImage>(_leagueImageDal.Get(p => p.Id == leagueId), "Lig ıd'ye göre lig logosu getirildi");
        }

        public IResult Update(IFormFile file, LeagueImage leagueImage)
        {
            throw new NotImplementedException();
        }
    }
}

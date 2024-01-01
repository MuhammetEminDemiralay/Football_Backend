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

        public async Task<IResult> AddAsync(IFormFile file, LeagueImage leagueImage)
        {
            leagueImage.LeagueImagePath= FileHelper.Add(file);
            leagueImage.Date = DateTime.Now;
            await _leagueImageDal.AddAsync(leagueImage);
            return new SuccessResult("Laegue image added");
        }

        public async Task<IResult> AddCollectiveAsync(IFormFile[] files, LeagueImage leagueImage)
        {
            foreach (var file in files)
            {
                leagueImage = new LeagueImage { LeagueId = leagueImage.LeagueId};
                await AddAsync(file, leagueImage);
            }
            return new SuccessResult("Oldu");
        }

        public async Task<IResult> DeleteAsync(LeagueImage leagueImage)
        {
            await _leagueImageDal.DeleteAsync(leagueImage);
            return new SuccessResult("league ımage delete");
        }

        public async Task<IDataResult<List<LeagueImage>>> GetAllAsync()
        {
            return new SuccessDataResult<List<LeagueImage>>(await _leagueImageDal.GetAllAsync(), "League image listed");
        }

        public async Task<IDataResult<LeagueImage>> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<LeagueImage>(await _leagueImageDal.GetAsync(p => p.Id == imageId));
        }

        public async Task<IDataResult<LeagueImage>> GetLeagueImageByLeagueIdAsync(int leagueId)
        {
            return new SuccessDataResult<LeagueImage>(await _leagueImageDal.GetAsync(p => p.LeagueId == leagueId), "Lig ıd'ye göre lig logosu getirildi");
        }

        public async Task<IResult> UpdateAsync(IFormFile file, LeagueImage leagueImage)
        {
            LeagueImage oldLeagueImage = GetImageByImageId(leagueImage.Id).Result.Data;
            leagueImage.LeagueImagePath = FileHelper.Update(file, oldLeagueImage.LeagueImagePath);
            leagueImage.Date = DateTime.Now;
            leagueImage.LeagueId = oldLeagueImage.LeagueId;
            _leagueImageDal.UpdateAsync(leagueImage);
            return new SuccessResult("league image updated");
        }
    }
}

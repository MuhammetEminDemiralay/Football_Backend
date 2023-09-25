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
    public class ClubImageManager : IClubImageService
    {
        IClubImageDal _clubImageDal;

        public ClubImageManager(IClubImageDal clubImageDal)
        {
            _clubImageDal = clubImageDal;
        }

        public async Task<IResult> AddAsync(IFormFile file, ClubImage clubImage)
        {
            clubImage.ClubImagePath = FileHelper.Add(file);
            clubImage.Date = DateTime.Now;
            await _clubImageDal.AddAsync(clubImage);
            return new SuccessResult("Club image added");
        }

        public async Task<IResult> AddCollectiveAsync(IFormFile[] files, ClubImage clubImage)
        {
            foreach (var file in files)
            {
                clubImage = new ClubImage { ClubId = clubImage.ClubId};
                await AddAsync(file, clubImage);
            }
            return new SuccessResult("Oldu");
        }

        public async Task<IResult> DeleteAsync(ClubImage clubImage)
        {
            await _clubImageDal.DeleteAsync(clubImage);
            return new SuccessResult("Club ımage deleted");
        }

        public async Task<IDataResult<List<ClubImage>>> GetAllAsync()
        {
            return new SuccessDataResult<List<ClubImage>>(await _clubImageDal.GetAllAsync(), "Club image listed");
        }

        public async Task<IDataResult<ClubImage>> GetImageByClubIdAsync(int clubId)
        {
            return new SuccessDataResult<ClubImage>(await _clubImageDal.GetAsync(p => p.Id == clubId), "Club ımage by club ıd get");
        }

        public async Task<IResult> UpdateAsync(IFormFile file, ClubImage clubImage)
        {
            throw new NotImplementedException();
        }
    }
}

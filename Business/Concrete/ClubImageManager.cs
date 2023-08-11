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

        public IResult Add(IFormFile file, ClubImage clubImage)
        {
            clubImage.ClubImagePath = FileHelper.Add(file);
            clubImage.Date = DateTime.Now;
            _clubImageDal.Add(clubImage);
            return new SuccessResult("Club image added");
        }

        public IResult AddCollective(IFormFile[] files, ClubImage clubImage)
        {
            foreach (var file in files)
            {
                clubImage = new ClubImage { ClubId = clubImage.ClubId};
                Add(file, clubImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(ClubImage clubImage)
        {
            _clubImageDal.Delete(clubImage);
            return new SuccessResult("Club ımage deleted");
        }

        public IDataResult<List<ClubImage>> GetAll()
        {
            return new SuccessDataResult<List<ClubImage>>(_clubImageDal.GetAll(), "Club image listed");
        }

        public IDataResult<ClubImage> GetImageByClubId(int clubId)
        {
            return new SuccessDataResult<ClubImage>(_clubImageDal.Get(p => p.Id == clubId), "Club ımage by club ıd get");
        }

        public IResult Update(IFormFile file, ClubImage clubImage)
        {
            throw new NotImplementedException();
        }
    }
}

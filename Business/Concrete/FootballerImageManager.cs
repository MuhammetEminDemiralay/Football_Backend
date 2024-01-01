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
    public class FootballerImageManager : IFootballerImageService
    {
        IFootballerImageDal _footballerImageDal;

        public FootballerImageManager(IFootballerImageDal footballerImageDal)
        {
            _footballerImageDal = footballerImageDal;
        }

        public async Task<IResult> AddAsync(IFormFile file, FootballerImage footballerImage)
        {
            footballerImage.FootballerImagePath = FileHelper.Add(file);
            footballerImage.Date = DateTime.Now;
            await _footballerImageDal.AddAsync(footballerImage);
            return new SuccessResult("Footballer image added");
        }

        public async Task<IResult> AddCollectiveAsync(IFormFile[] files, FootballerImage footballerImage)
        {
            foreach (var file in files)
            {
                footballerImage = new FootballerImage{ FootballerId = footballerImage.FootballerId };
                await AddAsync(file, footballerImage);
            }
            return new SuccessResult("Oldu");
        }

        public async Task<IResult> DeleteAsync(FootballerImage footballerImage)
        {
            await _footballerImageDal.DeleteAsync(footballerImage);
            return new SuccessResult("Footballer ımage delete");
        }

        public async Task<IDataResult<List<FootballerImage>>> GetAllAsync()
        {
            return new SuccessDataResult<List<FootballerImage>>(await _footballerImageDal.GetAllAsync(), "Footballer image listed");

        }

        public async Task<IDataResult<FootballerImage>> GetFootballerImageByFootballerIdAsync(int footballerId)
        {
            return new SuccessDataResult<FootballerImage>(await _footballerImageDal.GetAsync(p => p.Id == footballerId), "Futbolcu ıd'ye göre futbolcu resmi getirildi");

        }

        public async Task<IDataResult<FootballerImage>> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<FootballerImage>(await _footballerImageDal.GetAsync(p => p.Id == imageId));
        }

        public async Task<IResult> UpdateAsync(IFormFile file, FootballerImage footballerImage)
        {
            FootballerImage oldFootballerImage = GetImageByImageId(footballerImage.Id).Result.Data;
            footballerImage.FootballerImagePath= FileHelper.Update(file, oldFootballerImage.FootballerImagePath);
            footballerImage.Date = DateTime.Now;
            footballerImage.FootballerId= oldFootballerImage.FootballerId;
            _footballerImageDal.UpdateAsync(footballerImage);
            return new SuccessResult("Footballer image updated");
        }
    }
}

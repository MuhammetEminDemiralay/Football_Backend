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

        public IResult Add(IFormFile file, FootballerImage footballerImage)
        {
            footballerImage.FootballerImagePath = FileHelper.Add(file);
            footballerImage.Date = DateTime.Now;
            _footballerImageDal.Add(footballerImage);
            return new SuccessResult("Footballer image added");
        }

        public IResult AddCollective(IFormFile[] files, FootballerImage footballerImage)
        {
            foreach (var file in files)
            {
                footballerImage = new FootballerImage{ FootballerId = footballerImage.FootballerId };
                Add(file, footballerImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(FootballerImage footballerImage)
        {
            _footballerImageDal.Delete(footballerImage);
            return new SuccessResult("Footballer ımage delete");
        }

        public IDataResult<List<FootballerImage>> GetAll()
        {
            return new SuccessDataResult<List<FootballerImage>>(_footballerImageDal.GetAll(), "Footballer image listed");

        }

        public IDataResult<FootballerImage> GetFootballerImageByFootballerId(int footballerId)
        {
            return new SuccessDataResult<FootballerImage>(_footballerImageDal.Get(p => p.Id == footballerId), "Futbolcu ıd'ye göre futbolcu resmi getirildi");

        }

        public IResult Update(IFormFile file, FootballerImage footballerImage)
        {
            throw new NotImplementedException();
        }
    }
}

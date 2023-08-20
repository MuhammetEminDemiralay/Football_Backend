using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootballerImageService
    {
        IDataResult<List<FootballerImage>> GetAll();
        IDataResult<FootballerImage> GetFootballerImageByFootballerId(int footballerId);
        IResult Add(IFormFile file, FootballerImage footballerImage);
        IResult AddCollective(IFormFile[] files, FootballerImage footballerImage);
        IResult Update(IFormFile file, FootballerImage footballerImage);
        IResult Delete(FootballerImage footballerImage);
    }
}

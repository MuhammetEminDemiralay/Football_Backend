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
        Task<IDataResult<List<FootballerImage>>> GetAllAsync();
        Task<IDataResult<FootballerImage>> GetFootballerImageByFootballerIdAsync(int footballerId);
        Task<IResult> AddAsync(IFormFile file, FootballerImage footballerImage);
        Task<IResult> AddCollectiveAsync(IFormFile[] files, FootballerImage footballerImage);
        Task<IResult> UpdateAsync(IFormFile file, FootballerImage footballerImage);
        Task<IResult> DeleteAsync(FootballerImage footballerImage);
        Task<IDataResult<FootballerImage>> GetImageByImageId(int imageId);
    }
}

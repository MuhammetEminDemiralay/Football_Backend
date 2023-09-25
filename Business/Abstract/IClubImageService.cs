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
    public interface IClubImageService
    {
        Task<IDataResult<List<ClubImage>>> GetAllAsync();
        Task<IDataResult<ClubImage>> GetImageByClubIdAsync(int clubId);
        Task<IResult> AddAsync(IFormFile file, ClubImage carImage);
        Task<IResult> AddCollectiveAsync(IFormFile[] files, ClubImage clubImage);
        Task<IResult> UpdateAsync(IFormFile file, ClubImage clubImage);
        Task<IResult> DeleteAsync(ClubImage clubImage);
    }
}

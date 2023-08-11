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
        IDataResult<List<ClubImage>> GetAll();
        IDataResult<ClubImage> GetImageByClubId(int clubId);
        IResult Add(IFormFile file, ClubImage carImage);
        IResult AddCollective(IFormFile[] files, ClubImage clubImage);
        IResult Update(IFormFile file, ClubImage clubImage);
        IResult Delete(ClubImage clubImage);
    }
}

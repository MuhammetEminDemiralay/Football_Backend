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
    public interface ILeagueImageService
    {
        IDataResult<List<LeagueImage>> GetAll();
        IDataResult<LeagueImage> GetLeagueImageByLeagueId(int leagueId);
        IResult Add(IFormFile file, LeagueImage leagueImage);
        IResult AddCollective(IFormFile[] files, LeagueImage leagueImage);
        IResult Update(IFormFile file, LeagueImage leagueImage);
        IResult Delete(LeagueImage leagueImage);
    }
}

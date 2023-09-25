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
        Task<IDataResult<List<LeagueImage>>> GetAllAsync();
        Task<IDataResult<LeagueImage>> GetLeagueImageByLeagueIdAsync(int leagueId);
        Task<IResult> AddAsync(IFormFile file, LeagueImage leagueImage);
        Task<IResult> AddCollectiveAsync(IFormFile[] files, LeagueImage leagueImage);
        Task<IResult> UpdateAsync(IFormFile file, LeagueImage leagueImage);
        Task<IResult> DeleteAsync(LeagueImage leagueImage);
    }
}

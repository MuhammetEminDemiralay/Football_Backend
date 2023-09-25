using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClubService
    {
        Task<IDataResult<List<Club>>> GetAllAsync();
        Task<IDataResult<Club>> GetAsync(int id);
        Task<IDataResult<ClubDetailDto>> GetClubDetailByClubIdAsync(int clubId);
        Task<IResult> AddAsync(Club club);
        Task<IResult> UpdateAsync(Club club);
        Task<IResult> DeleteAsync(Club club);


        Task<IDataResult<List<ClubDetailDto>>> GetClubsDetailByLeagueIdAsync(int leagueId);

    }
}

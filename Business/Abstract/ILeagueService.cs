using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILeagueService
    {
        Task<IDataResult<List<League>>> GetAllAsync();
        Task<IDataResult<LeagueDetailDto>> GetLegaueDetailByLeagueIdAsync(int leagueId);
        Task<IResult> AddAsync(League league);
        Task<IResult> UpdateAsync(League league);
        Task<IResult> DeleteAsync(League league);
        Task<IDataResult<List<LeagueDetailDto>>> GetLeaguesbyCountryIdAsync(int countryId);
    }
}

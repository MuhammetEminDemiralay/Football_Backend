using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILeagueDal : IEntityRepository<League>
    {
        Task<List<LeagueDetailDto>> GetLeagueDetailByCountryId(Expression<Func<LeagueDetailDto, bool>> filter = null);
        Task<LeagueDetailDto> GetLeagueDetailByLeagueIdAsync(Expression<Func<LeagueDetailDto, bool>> filter);
    }
}

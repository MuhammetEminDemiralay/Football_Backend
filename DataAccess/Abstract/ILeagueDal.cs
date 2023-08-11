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
        List<LeagueDetailDto> GetLeagueDetailDtos(Expression<Func<LeagueDetailDto, bool>> filter = null);
        LeagueDetailDto GetLeagueDetailByLeagueId(Expression<Func<LeagueDetailDto, bool>> filter);
    }
}

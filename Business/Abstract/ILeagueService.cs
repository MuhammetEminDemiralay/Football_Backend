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
        IDataResult<List<League>> GetAll();
        IDataResult<LeagueDetailDto> GetLegaueDetailByLeagueId(int leagueId);
        IResult Add(League league);
        IResult Update(League league);
        IResult Delete(League league);
        IDataResult<List<LeagueDetailDto>> GetLeaguesbyCountryId(int countryId);
    }
}

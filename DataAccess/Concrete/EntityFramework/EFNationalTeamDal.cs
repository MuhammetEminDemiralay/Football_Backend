using Core.DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFNationalTeamDal : EFEntityRepositoryBase<NationalTeam, FootballContext>, INationalTeamDal
    {
        public async Task<List<NationalTeamDetailDto>> GetNationalTeamDetailByCountryIdAsync(Expression<Func<NationalTeamDetailDto, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = from nationalTeam in context.NationalTeams
                             join countryImage in context.CountryImages
                             on nationalTeam.CountryId equals countryImage.CountryId
                             select new NationalTeamDetailDto
                             {
                                 Id = nationalTeam.Id,
                                 CountryId = nationalTeam.CountryId,
                                 NationalTeamImagePath = countryImage.CountryImagePath,
                                 NationalTeamName = nationalTeam.NationalTeamName,
                                 Date = countryImage.Date,
                                 NationalTeamLevel = nationalTeam.NationalTeamLevel,
                                 SquadSize = nationalTeam.SquadSize,
                                 AverageAge = nationalTeam.AverageAge,
                                 MarketValue = nationalTeam.MarketValue
                             };

                return await (filter == null ? result.ToListAsync() : result.Where(filter).ToListAsync());

            }
        }

        public async Task<NationalTeamDetailDto> GetNationalTeamDetailByNationalTeamIdAsync(Expression<Func<NationalTeamDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from nationalTeam in context.NationalTeams
                             join countryImage in context.CountryImages
                             on nationalTeam.CountryId equals countryImage.CountryId

                             select new NationalTeamDetailDto
                             {
                                 Id = nationalTeam.Id,
                                 CountryId = nationalTeam.CountryId,
                                 NationalTeamImagePath = countryImage.CountryImagePath,
                                 NationalTeamName = nationalTeam.NationalTeamName,
                                 Date = countryImage.Date,
                                 NationalTeamLevel = nationalTeam.NationalTeamLevel,
                                 SquadSize = nationalTeam.SquadSize,
                                 AverageAge = nationalTeam.AverageAge,
                                 MarketValue = nationalTeam.MarketValue
                             };

                return await result.Where(filter).SingleOrDefaultAsync();
            }
        }
    }
}

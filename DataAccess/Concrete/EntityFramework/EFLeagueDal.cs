using Core.DataAccess.Concrete.EntityFramework;
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
    public class EFLeagueDal : EFEntityRepositoryBase<League, FootballContext>, ILeagueDal
    {


        public async Task<List<LeagueDetailDto>> GetLeagueDetailByCountryId(Expression<Func<LeagueDetailDto, bool>> filter = null)
        {
            using(var context = new FootballContext())
            {
                var result = from league in context.Leagues




                             select new LeagueDetailDto
                             {
                                 Id = league.Id,
                                 CountryId = league.CountryId,
                                 LeagueImagePath = (from image in context.LeagueImages where image.LeagueId == league.Id select image.LeagueImagePath).FirstOrDefault(),
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName,
                                 NumberOfTeams = league.NumberOfTeams,
                                 Players = league.Players,
                                 ReigningChampion = league.ReigningChampion,
                                 TotalMarketValue = league.TotalMarketValue,

                             };

                return await (filter == null ? result.ToListAsync() : result.Where(filter).ToListAsync());
            }
        }

        public async Task<LeagueDetailDto> GetLeagueDetailByLeagueIdAsync(Expression<Func<LeagueDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from league in context.Leagues
                             join country in context.Countrys
                             on league.CountryId equals country.Id

                             select new LeagueDetailDto
                             {
                                 Id = league.Id,
                                 CountryId = league.CountryId,
                                 LeagueImagePath = (from image in context.LeagueImages where image.LeagueId == league.Id select image.LeagueImagePath).FirstOrDefault(),
                                 CountryImagePath = (from image in context.CountryImages where image.CountryId== country.Id select image.CountryImagePath).FirstOrDefault(),
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName,
                                 NumberOfTeams = league.NumberOfTeams,
                                 Players = league.Players,
                                 ReigningChampion = league.ReigningChampion,
                                 TotalMarketValue = league.TotalMarketValue,
                                 CountryName = country.CountryName
                             };

                return await result.Where(filter).SingleOrDefaultAsync();

            }
        }
    }
}

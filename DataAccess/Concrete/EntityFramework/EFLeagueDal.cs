using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
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


        public List<LeagueDetailDto> GetLeagueDetailDtos(Expression<Func<LeagueDetailDto, bool>> filter = null)
        {
            using(var context = new FootballContext())
            {
                var result = from league in context.Leagues
                             join leagueImage in context.LeagueImages
                             on league.LeagueImageId equals leagueImage.Id


                             select new LeagueDetailDto
                             {
                                 Id = league.Id,
                                 LeagueId = leagueImage.Id,
                                 LeagueImageId = leagueImage.Id,
                                 CountryId = league.CountryId,
                                 Date = leagueImage.Date,
                                 LeagueImagePath = leagueImage.LeagueImagePath,
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName,
                                 NumberOfTeams = league.NumberOfTeams,
                                 Players = league.Players,
                                 ReigningChampion = league.ReigningChampion,
                                 TotalMarketValue = league.TotalMarketValue

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public LeagueDetailDto GetLeagueDetailByLeagueId(Expression<Func<LeagueDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from league in context.Leagues
                             join leagueImage in context.LeagueImages
                             on league.LeagueImageId equals leagueImage.Id


                             select new LeagueDetailDto
                             {
                                 Id = league.Id,
                                 LeagueId = leagueImage.Id,
                                 LeagueImageId = leagueImage.Id,
                                 CountryId = league.CountryId,
                                 Date = leagueImage.Date,
                                 LeagueImagePath = leagueImage.LeagueImagePath,
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName,
                                 NumberOfTeams = league.NumberOfTeams,
                                 Players = league.Players,
                                 ReigningChampion = league.ReigningChampion,
                                 TotalMarketValue = league.TotalMarketValue,
                                 
                             };

                return result.FirstOrDefault(filter);

            }
        }
    }
}

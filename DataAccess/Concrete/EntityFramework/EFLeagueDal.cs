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
                             on league.Id equals leagueImage.LeagueId



                             select new LeagueDetailDto
                             {
                                 Id = league.Id,
                                 CountryId = league.CountryId,
                                 Date = leagueImage.Date,
                                 LeagueImagePath = (from image in context.LeagueImages where image.LeagueId == league.Id select image.LeagueImagePath).FirstOrDefault(),
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName,
                                 NumberOfTeams = league.NumberOfTeams,
                                 Players = league.Players,
                                 ReigningChampion = league.ReigningChampion,
                                 TotalMarketValue = league.TotalMarketValue,
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
                             on league.Id equals leagueImage.LeagueId
                             join countryImage in context.CountryImages
                             on league.CountryId equals countryImage.CountryId
                             join country in context.Countrys
                             on league.CountryId equals country.Id

                             select new LeagueDetailDto
                             {
                                 Id = league.Id,
                                 CountryId = league.CountryId,
                                 Date = leagueImage.Date,
                                 LeagueImagePath = leagueImage.LeagueImagePath,
                                 CountryImagePath = countryImage.CountryImagePath,
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName,
                                 NumberOfTeams = league.NumberOfTeams,
                                 Players = league.Players,
                                 ReigningChampion = league.ReigningChampion,
                                 TotalMarketValue = league.TotalMarketValue,
                                 CountryName = country.CountryName
                             };

                return result.Where(filter).FirstOrDefault();

            }
        }
    }
}

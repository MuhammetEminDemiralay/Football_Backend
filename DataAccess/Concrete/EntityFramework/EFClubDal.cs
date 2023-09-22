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
    public class EFClubDal : EFEntityRepositoryBase<Club, FootballContext>, IClubDal
    {

        public List<ClubDetailDto> GetClubDetailDto(Expression<Func<ClubDetailDto, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = from club in context.Clubs
                             join clubImage in context.ClubImages
                             on club.Id equals clubImage.ClubId


                             select new ClubDetailDto
                             {
                                 Id = club.Id,
                                 LeagueId = club.LeagueId,
                                 CountryId = club.CountryId,
                                 ClubImagePath = clubImage.ClubImagePath,
                                 ClubMarketValue = club.ClubMarketValue,
                                 AverageAge = club.AverageAge,
                                 ClubName = club.ClubName,
                                 CurrentTransferRecord = club.CurrentTransferRecord,
                                 Date = clubImage.Date,
                                 Foreigners = (from footballers in context.Footballers where footballers.CountryId == club.CountryId select footballers.Name).Count(),
                                 NationalTeamPlayers = (from footballers in context.Footballers where footballers.ClubId == club.Id && footballers.NationalTeamPlayerActive == true select footballers.Name).Count(),
                                 SquadSize = club.SquadSize,
                                 StadiumCapacity = club.StadiumCapacity,
                                 StadiumName = club.StadiumName
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public ClubDetailDto GetClubDetailByClubId(Expression<Func<ClubDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from club in context.Clubs
                             join clubImage in context.ClubImages
                             on club.Id equals clubImage.ClubId
                             join leagueImage in context.LeagueImages
                             on club.LeagueId equals leagueImage.LeagueId
                             join countryImage in context.CountryImages
                             on club.CountryId equals countryImage.CountryId
                             join league in context.Leagues
                             on club.LeagueId equals league.Id


                             select new ClubDetailDto
                             {
                                 Id = club.Id,
                                 LeagueId = club.LeagueId,
                                 CountryId = club.CountryId,
                                 ClubImagePath = clubImage.ClubImagePath,
                                 LeagueImagePath = leagueImage.LeagueImagePath,
                                 CountryImagePath = countryImage.CountryImagePath,
                                 ClubMarketValue = club.ClubMarketValue,
                                 AverageAge = club.AverageAge,
                                 ClubName = club.ClubName,
                                 CurrentTransferRecord = club.CurrentTransferRecord,
                                 Date = clubImage.Date,
                                 Foreigners = (from footballers in context.Footballers where footballers.ClubId == club.Id && footballers.CountryId != club.CountryId select footballers.Name).Count(),
                                 NationalTeamPlayers = (from footballers in context.Footballers where footballers.ClubId == club.Id && footballers.NationalTeamPlayerActive == true select footballers.Name).Count(),
                                 SquadSize = club.SquadSize,
                                 StadiumCapacity = club.StadiumCapacity,
                                 StadiumName = club.StadiumName,
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName
                             };

                return result.Where(filter).FirstOrDefault();
            }
        }
    }
}

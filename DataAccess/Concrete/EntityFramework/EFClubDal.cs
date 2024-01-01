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
    public class EFClubDal : EFEntityRepositoryBase<Club, FootballContext>, IClubDal
    {

        public async Task<List<ClubDetailDto>> GetClubDetailAsync(Expression<Func<ClubDetailDto, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = from club in context.Clubs

                             select new ClubDetailDto
                             {
                                 Id = club.Id,
                                 LeagueId = club.LeagueId,
                                 CountryId = club.CountryId,
                                 ClubImagePath = (from image in context.ClubImages where image.ClubId == club.Id select image.ClubImagePath).FirstOrDefault(),
                                 ClubMarketValue = club.ClubMarketValue,
                                 AverageAge = club.AverageAge,
                                 ClubName = club.ClubName,
                                 CurrentTransferRecord = club.CurrentTransferRecord,
                                 Foreigners = (from footballers in context.Footballers where footballers.CountryId == club.CountryId select footballers.Name).Count(),
                                 NationalTeamPlayers = (from footballers in context.Footballers where footballers.ClubId == club.Id && footballers.NationalTeamPlayerActive == true select footballers.Name).Count(),
                                 SquadSize = club.SquadSize,
                                 StadiumCapacity = club.StadiumCapacity,
                                 StadiumName = club.StadiumName
                             };

                return await (filter == null ? result.ToListAsync() : result.Where(filter).ToListAsync());
            }
        }

        public async Task<ClubDetailDto> GetClubDetailByClubIdAsync(Expression<Func<ClubDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from club in context.Clubs
                             join league in context.Leagues
                             on club.LeagueId equals league.Id


                             select new ClubDetailDto
                             {
                                 Id = club.Id,
                                 LeagueId = club.LeagueId,
                                 CountryId = club.CountryId,
                                 ClubImagePath = (from image in context.ClubImages where image.ClubId == club.Id select image.ClubImagePath).FirstOrDefault(),
                                 LeagueImagePath = (from image in context.LeagueImages where image.LeagueId == club.LeagueId select image.LeagueImagePath).FirstOrDefault(),
                                 CountryImagePath = (from image in context.CountryImages where image.CountryId == club.CountryId select image.CountryImagePath).FirstOrDefault(),
                                 ClubMarketValue = club.ClubMarketValue,
                                 AverageAge = club.AverageAge,
                                 ClubName = club.ClubName,
                                 CurrentTransferRecord = club.CurrentTransferRecord,
                                 Foreigners = (from footballers in context.Footballers where footballers.ClubId == club.Id && footballers.CountryId != club.CountryId select footballers.Name).Count(),
                                 NationalTeamPlayers = (from footballers in context.Footballers where footballers.ClubId == club.Id && footballers.NationalTeamPlayerActive == true select footballers.Name).Count(),
                                 SquadSize = club.SquadSize,
                                 StadiumCapacity = club.StadiumCapacity,
                                 StadiumName = club.StadiumName,
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName
                             };

                return await result.Where(filter).SingleOrDefaultAsync();
            }
        }
    }
}

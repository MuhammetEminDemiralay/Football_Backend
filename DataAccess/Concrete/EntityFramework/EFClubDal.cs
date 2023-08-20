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
                                 ClubImageId = clubImage.Id,
                                 ClubImagePath = clubImage.ClubImagePath,
                                 ClubMarketValue = club.ClubMarketValue,
                                 AverageAge = club.AverageAge,
                                 ClubName = club.ClubName,
                                 CurrentTransferRecord = club.CurrentTransferRecord,
                                 Date = clubImage.Date,
                                 Foreigners = club.Foreigners,
                                 NationalTeamPlayers = club.NationalTeamPlayers,
                                 SquadSize = club.SquadSize,
                                 StadiumCapacity = club.StadiumCapacity,
                                 StadiumName = club.StadiumName
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

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
    public class EFTransferHistoryDal : EFEntityRepositoryBase<TransferHistory, FootballContext>, ITransferHistoryDal
    {
        public List<TransferHistoryDto> GetFootballerTransferHistory(Expression<Func<TransferHistoryDto, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = from transferHistory in context.TransferHistorys
                             join beforeClub in context.Clubs
                             on transferHistory.CurrentClubId equals beforeClub.Id
                             join lastClub in context.Clubs
                             on transferHistory.LastClubId equals lastClub.Id
                             join footballer in context.Footballers
                             on transferHistory.FootballerId equals footballer.Id


                             select new TransferHistoryDto
                             {
                                 FootballerId = transferHistory.FootballerId,
                                 BeforeClubCountryImagePath = (from beforeClubCountryImagePath in context.CountryImages where beforeClubCountryImagePath.CountryId == beforeClub.CountryId select beforeClubCountryImagePath.CountryImagePath).SingleOrDefault(),
                                 BeforeClubImagePath = (from beforeClubImagePath in context.ClubImages where beforeClubImagePath.ClubId == transferHistory.CurrentClubId select beforeClubImagePath.ClubImagePath).SingleOrDefault(),
                                 BeforeClubName = beforeClub.ClubName,
                                 LastClubCountryImagePath = (from lastClubCountryImagePath in context.CountryImages where lastClubCountryImagePath.CountryId == lastClub.CountryId select lastClubCountryImagePath.CountryImagePath).SingleOrDefault(),
                                 LastClubImagePath = (from lastClubImagePath in context.ClubImages where lastClubImagePath.ClubId == transferHistory.LastClubId select lastClubImagePath.ClubImagePath).SingleOrDefault(),
                                 LastClubName = lastClub.ClubName,
                                 Joined = transferHistory.Joined,
                                 ContractExpires = transferHistory.ContractExpires,
                                 Fee = transferHistory.Fee,
                                 MarketValue = footballer.FootballerValue,
                                 Season = transferHistory.Season
                            };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}

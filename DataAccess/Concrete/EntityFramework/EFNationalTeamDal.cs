using Core.DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results;
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
    public class EFNationalTeamDal : EFEntityRepositoryBase<NationalTeam, FootballContext>, INationalTeamDal
    {
        public List<NationalTeamDetailDto> GetNationalTeamDetailByCountryId(Expression<Func<NationalTeamDetailDto, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = from nationalTeam in context.NationalTeams
                             join countryImage in context.CountryImages
                             on nationalTeam.CountryImageId equals countryImage.Id

                             select new NationalTeamDetailDto
                             {
                                 Id = nationalTeam.Id,
                                 CountryId = nationalTeam.CountryId,
                                 CountryImageId = countryImage.Id,
                                 CountryImagePath = countryImage.CountryImagePath,
                                 NationalTeamName = nationalTeam.NationalTeamName,
                                 Date = countryImage.Date,
                                 NationalTeamLevel = nationalTeam.NationalTeamLevel,
                                 SquadSize = nationalTeam.SquadSize,
                                 AverageAge = nationalTeam.AverageAge,
                                 MarketValue = nationalTeam.MarketValue
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}

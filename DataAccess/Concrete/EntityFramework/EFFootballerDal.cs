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
    public class EFFootballerDal : EFEntityRepositoryBase<Footballer, FootballContext>, IFootballerDal
    {


        public List<FootballerDetailDto> GetFootballersDetailByClubId(Expression<Func<FootballerDetailDto, bool>> filter = null)
        {
            using(var context = new FootballContext())
            {
                var result = from footballer in context.Footballers
                             join footballerImage in context.FootballerImages
                             on footballer.Id equals footballerImage.FootballerId
                             join position in context.Positions
                             on footballer.PositionId equals position.Id
                             join countryImage in context.CountryImages
                             on footballer.CountryId equals countryImage.CountryId
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id

                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerImagePath = footballerImage.FootballerImagePath,
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootballerCountryImagePath = countryImage.CountryImagePath,
                                 FootName = foot.FootName,
                                 
                                 
                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public FootballerDetailDto GetFootballerDetailByFootballerId(Expression<Func<FootballerDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from footballer in context.Footballers
                             join footballerImage in context.FootballerImages
                             on footballer.Id equals footballerImage.FootballerId
                             join position in context.Positions
                             on footballer.PositionId equals position.Id
                             join countryImage in context.CountryImages
                             on footballer.CountryId equals countryImage.CountryId
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id
                             from leagueCountry in context.Leagues
                             join leagueCountryImage in context.CountryImages
                             on leagueCountry.CountryId equals leagueCountryImage.CountryId
                             join clubImage in context.ClubImages
                             on footballer.ClubId equals clubImage.ClubId
                             join leagueImage in context.LeagueImages
                             on footballer.LeagueId equals leagueImage.LeagueId
                             join league in context.Leagues
                             on footballer.LeagueId equals league.Id
                             join country in context.Countrys
                             on footballer.CountryId equals country.Id

                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerImagePath = footballerImage.FootballerImagePath,
                                 FootballerCountryImagePath = countryImage.CountryImagePath,
                                 LeagueCountryImagePath = leagueCountryImage.CountryImagePath,
                                 ClubImagePath = clubImage.ClubImagePath,
                                 LeagueImagePath = leagueImage.LeagueImagePath,
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootName = foot.FootName,
                                 FootballerCountryName = country.CountryName,
                                 LeagueLevel = league.LeagueLevel,
                                 LeagueName = league.LeagueName
                             };

                return result.Where(filter).FirstOrDefault();

            }
        }
    }
}

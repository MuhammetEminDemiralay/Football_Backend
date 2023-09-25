using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFFootballerDal : EFEntityRepositoryBase<Footballer, FootballContext>, IFootballerDal
    {

        public async Task<List<FootballerDetailDto>> GetFootballersDetailByCountryIdAsync(Expression<Func<FootballerDetailDto, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = from footballer in context.Footballers
                             join position in context.Positions
                             on footballer.PositionId equals position.Id
                             join countryImage in context.CountryImages
                             on footballer.CountryId equals countryImage.CountryId
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id
                             join city in context.Citys
                             on footballer.CityId equals city.Id
                             join country in context.Countrys
                             on footballer.CountryId equals country.Id


                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerImagePath = (from img in context.FootballerImages where img.FootballerId == footballer.Id select img.FootballerImagePath).FirstOrDefault(),
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootballerCountryImagePath = countryImage.CountryImagePath,
                                 FootName = foot.FootName,
                                 CityId = city.Id,
                                 FootId = foot.Id,
                                 PositionId = position.Id,
                                 FootballerCountryName = country.CountryName,
                                 NationalTeamPlayerActive = footballer.NationalTeamPlayerActive,
                                 NationalTeamLevel = footballer.NationalTeamLevel,
                                 FootballerClubImagePath = (from img in context.ClubImages where img.ClubId == footballer.ClubId select img.ClubImagePath).FirstOrDefault()
                             };


                return await (filter == null ? result.ToListAsync() : result.Where(filter).ToListAsync());

            }
        }


        public async Task<List<FootballerDetailDto>> GetFootballersDetailByClubIdAsync(Expression<Func<FootballerDetailDto, bool>> filter = null)
        {
            using(var context = new FootballContext())
            {
                var result = from footballer in context.Footballers
                             join position in context.Positions
                             on footballer.PositionId equals position.Id
                             join countryImage in context.CountryImages
                             on footballer.CountryId equals countryImage.CountryId
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id
                             join city in context.Citys
                             on footballer.CityId equals city.Id
                             join country in context.Countrys
                             on footballer.CountryId equals country.Id


                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerImagePath = (from img in context.FootballerImages where img.FootballerId == footballer.Id select img.FootballerImagePath).FirstOrDefault(),
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootballerCountryImagePath = countryImage.CountryImagePath,
                                 FootName = foot.FootName,       
                                 CityId = city.Id,
                                 FootId = foot.Id,
                                 PositionId = position.Id,
                                 FootballerCountryName = country.CountryName
                                 
                             };


                return await (filter == null ? result.ToListAsync() : result.Where(filter).ToListAsync());

            }
        }

        public async Task<FootballerDetailDto> GetFootballerDetailByFootballerIdAsync(Expression<Func<FootballerDetailDto, bool>> filter)
        {
            using (var context = new FootballContext())
            {
                var result = from footballer in context.Footballers
                             join position in context.Positions
                             on footballer.PositionId equals position.Id
                             join countryImage in context.CountryImages
                             on footballer.CountryId equals countryImage.CountryId
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id
                             join country in context.Countrys
                             on footballer.CountryId equals country.Id
                             join city in context.Citys
                             on footballer.CityId equals city.Id
                             join clubImage in context.ClubImages
                             on footballer.ClubId equals clubImage.ClubId
                             join club in context.Clubs
                             on footballer.ClubId equals club.Id
                             


                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerImagePath = (from img in context.FootballerImages where img.FootballerId == footballer.Id select img.FootballerImagePath).FirstOrDefault(),
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootName = foot.FootName,
                                 FootballerCountryImagePath = countryImage.CountryImagePath,
                                 FootballerCountryName = country.CountryName,
                                 CityId = city.Id,
                                 FootId = foot.Id,
                                 PositionId = position.Id,
                                 CityName = city.CityName,
                                 ClubName = club.ClubName,
                                 FootballerClubImagePath = clubImage.ClubImagePath,
                                 NationalTeamPlayerActive = footballer.NationalTeamPlayerActive,
                                 NationalTeamLevel = footballer.NationalTeamLevel
                                 
                                 
                             };

                return await result.Where(filter).SingleOrDefaultAsync();

            }
        }
    }
}

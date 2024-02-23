using Core.DataAccess.Concrete.EntityFramework;
using Core.RequestFeatures;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Extensions;
using Entities.RequestFeatures;
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
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id
                             join city in context.Citys
                             on footballer.CityId equals city.Id
                             join country in context.Countrys
                             on footballer.CountryId equals country.Id
                             join transferHistory in context.TransferHistorys
                             on footballer.Id equals transferHistory.FootballerId

                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerCountryImagePath = (from img in context.CountryImages where img.CountryId == footballer.CountryId select img.CountryImagePath).FirstOrDefault(),
                                 FootballerClubImagePath = (from img in context.ClubImages where img.ClubId == footballer.ClubId select img.ClubImagePath).FirstOrDefault(),
                                 FootballerImagePath = (from img in context.FootballerImages where img.FootballerId == footballer.Id select img.FootballerImagePath).FirstOrDefault(),
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootName = foot.FootName,
                                 CityId = city.Id,
                                 FootId = foot.Id,
                                 PositionId = position.Id,
                                 FootballerCountryName = country.CountryName,
                                 NationalTeamPlayerActive = footballer.NationalTeamPlayerActive,
                                 NationalTeamLevel = footballer.NationalTeamLevel,
                                 NameInHomeCountry = footballer.NameInHomeCountry,
                                 PlaceOfBirth = footballer.PlaceOfBirth,
                                 PlayerAgent = footballer.PlayerAgent,
                                 DateOfLastContract = transferHistory.DateOfLastContract,
                                 Joined = transferHistory.Joined,
                                 ContractExpires = transferHistory.ContractExpires
                             };

                return await (filter == null ? result.ToListAsync() : result.Where(filter).ToListAsync());
            }
        }


        public async Task<List<FootballerDetailDto>> GetFootballersDetailByClubIdAsync(Expression<Func<FootballerDetailDto, bool>> filter = null)
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
                             join transferHistory in context.TransferHistorys
                             on footballer.Id equals transferHistory.FootballerId

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
                                 NameInHomeCountry = footballer.NameInHomeCountry,
                                 PlaceOfBirth = footballer.PlaceOfBirth,
                                 PlayerAgent = footballer.PlayerAgent,
                                 DateOfLastContract = transferHistory.DateOfLastContract,
                                 Joined = transferHistory.Joined,
                                 ContractExpires = transferHistory.ContractExpires
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
                             join foot in context.Foots
                             on footballer.FootId equals foot.Id
                             join country in context.Countrys
                             on footballer.CountryId equals country.Id
                             join city in context.Citys
                             on footballer.CityId equals city.Id
                             join club in context.Clubs
                             on footballer.ClubId equals club.Id
                             join transferHistory in context.TransferHistorys
                             on footballer.Id equals transferHistory.FootballerId

                             select new FootballerDetailDto
                             {
                                 Id = footballer.Id,
                                 ClubId = footballer.ClubId,
                                 LeagueId = footballer.LeagueId,
                                 CountryId = footballer.CountryId,
                                 DateOfBirth = footballer.DateOfBirth,
                                 FootballerClubImagePath = (from img in context.ClubImages where img.ClubId == footballer.ClubId select img.ClubImagePath).FirstOrDefault(),
                                 FootballerCountryImagePath = (from img in context.CountryImages where img.CountryId == footballer.CountryId select img.CountryImagePath).FirstOrDefault(),
                                 FootballerImagePath = (from img in context.FootballerImages where img.FootballerId == footballer.Id select img.FootballerImagePath).FirstOrDefault(),
                                 PlayerNumber = footballer.PlayerNumber,
                                 PositionName = position.PositionName,
                                 Age = footballer.Age,
                                 Height = footballer.Height,
                                 Name = footballer.Name,
                                 FootballerValue = footballer.FootballerValue,
                                 FootName = foot.FootName,
                                 FootballerCountryName = country.CountryName,
                                 CityId = city.Id,
                                 FootId = foot.Id,
                                 PositionId = position.Id,
                                 CityName = city.CityName,
                                 ClubName = club.ClubName,
                                 NationalTeamPlayerActive = footballer.NationalTeamPlayerActive,
                                 NationalTeamLevel = footballer.NationalTeamLevel,
                                 NameInHomeCountry = footballer.NameInHomeCountry,
                                 PlaceOfBirth = footballer.PlaceOfBirth,
                                 PlayerAgent = footballer.PlayerAgent,
                                 DateOfLastContract = transferHistory.DateOfLastContract,
                                 Joined = transferHistory.Joined,
                                 ContractExpires = transferHistory.ContractExpires
                             };

                return await result.Where(filter).SingleOrDefaultAsync();

            }


        }

        public async Task<PagedList<Footballer>> GetAllTryFootballer(FootballerParameters parameters, Expression<Func<Footballer, bool>> filter = null)
        {
            using (var context = new FootballContext())
            {
                var result = await (filter == null ? context.Set<Footballer>().Search(parameters.SearchTerm).ToListAsync() : context.Set<Footballer>().Where(filter).Search(parameters.SearchTerm).ToListAsync());

                return PagedList<Footballer>.ToPagedList(result, parameters.PageNumber, parameters.PageSize);

            }
        }
    }
}

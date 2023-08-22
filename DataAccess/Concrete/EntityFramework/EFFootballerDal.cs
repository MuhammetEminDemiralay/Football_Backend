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
                                 CountryImagePath = countryImage.CountryImagePath,
                                 FootName = foot.FootName
                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}

using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFootballerDal : IEntityRepository<Footballer>
    {
        Task<List<FootballerDetailDto>> GetFootballersDetailByCountryIdAsync(Expression<Func<FootballerDetailDto, bool>> filter = null);
        Task<List<FootballerDetailDto>> GetFootballersDetailByClubIdAsync(Expression<Func<FootballerDetailDto, bool>> filter = null);
        Task<FootballerDetailDto> GetFootballerDetailByFootballerIdAsync(Expression<Func<FootballerDetailDto, bool>> filter);


    }
}

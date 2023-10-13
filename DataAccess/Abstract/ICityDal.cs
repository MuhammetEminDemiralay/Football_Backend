using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
        Task<List<City>> GetAllTryCity(CityParameters parameters, Expression<Func<FootballerDetailDto, bool>> filter = null);
    }
}

using Core.DataAccess.Concrete.EntityFramework;
using Core.RequestFeatures;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCityDal : EFEntityRepositoryBase<City, FootballContext>, ICityDal
    {
        public async Task<PagedList<City>> GetAllTryCity(CityParameters parameters, Expression<Func<City, bool>> filter = null)
        {
            using(var context = new FootballContext())
            {
                var result = await (filter == null ? context.Set<City>().ToListAsync() : context.Set<City>().Where(filter).ToListAsync());

                return PagedList<City>.ToPagedList(result, parameters.PageNumber, parameters.PageSize);

            }
        }
    }
}

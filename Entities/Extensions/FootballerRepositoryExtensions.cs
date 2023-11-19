using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Extensions
{
    public static class FootballerRepositoryExtensions
    {
        public static IQueryable<Footballer> Search(this IQueryable<Footballer> footballer, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return footballer;
            var lowerTerm = searchTerm.Trim().ToLower();
            return footballer.Where(f => f.Name.ToLower().Contains(lowerTerm));
        }

        //public static void ConfigureDataShaper(this IServiceCollection services)
        //{
        //    services.AddScoped<IDataShaper<Footballer>, DataShaper<Footballer>>();
        //}
    }
}

using DataAccess.Concrete.EntityFramework.Context;
using Entities.AuthenticationModel;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 6;

                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<FootballContext>()
                .AddDefaultTokenProviders();
        }
    }
}

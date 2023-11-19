using Entities.AuthenticationModel;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class FootballContext : IdentityDbContext<User>
    {
        public DbSet<CareerStat> CareerStats { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<NationalTeam> NationalTeams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TransferHistory> TransferHistorys { get; set; }
        public DbSet<CountryImage> CountryImages { get; set; }
        public DbSet<LeagueImage> LeagueImages { get; set; }
        public DbSet<ClubImage> ClubImages { get; set; }
        public DbSet<FootballerImage> FootballerImages{ get; set; }
        public DbSet<Foot> Foots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Football;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

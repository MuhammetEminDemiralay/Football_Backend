using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class FootballContext : DbContext
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
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Football;");
        }

    }
}

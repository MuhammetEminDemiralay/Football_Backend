using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class LeagueDetailDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string? LeagueImagePath { get; set; }
        public string CountryImagePath { get; set; }
        public string CountryName { get; set; }
        public DateTime Date { get; set; }
        public string LeagueName { get; set; }
        public int NumberOfTeams { get; set; }
        public int TotalMarketValue { get; set; }
        public int Players { get; set; }
        public int LeagueLevel { get; set; }
        public int ReigningChampion { get; set; }
        public int? Foreigners{ get; set; }
    }
}

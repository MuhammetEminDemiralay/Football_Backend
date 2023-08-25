using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class League :IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string LeagueName { get; set; }
        public int NumberOfTeams { get; set; }
        public int TotalMarketValue { get; set; }
        public int Players { get; set; }
        public int LeagueLevel { get; set; }
        public int ReigningChampion { get; set; }
    }
}

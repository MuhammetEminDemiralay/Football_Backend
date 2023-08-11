using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ClubDetailDto : IDto
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int ClubId { get; set; }
        public int ClubImageId { get; set; }
        public string ClubImagePath { get; set; }
        public DateTime Date { get; set; }
        public string ClubName { get; set; }
        public int SquadSize { get; set; }
        public int AverageAge { get; set; }
        public int NationalTeamPlayers { get; set; }
        public int Foreigners { get; set; }
        public string StadiumName { get; set; }
        public int StadiumCapacity { get; set; }
        public int CurrentTransferRecord { get; set; }
        public int ClubMarketValue { get; set; }
    }
}

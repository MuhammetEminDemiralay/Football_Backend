using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Footballer : IEntity
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int LeagueId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int? TransferHistoryId { get; set; }
        public int? CareerStatId { get; set; }
        public int PositionId { get; set; }
        public int? OutfitterId { get; set; }
        public int FootId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int FootballerValue { get; set; }
        public int PlayerNumber { get; set; }
        public bool? NationalTeamPlayerActive { get; set; }
        public int? NationalTeamLevel { get; set; }


    }
}

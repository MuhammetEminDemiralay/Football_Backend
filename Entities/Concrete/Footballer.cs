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
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int TransferHistoryId { get; set; }
        public int CareerStatId { get; set; }
        public int PositionId { get; set; }
        public int CurrentClubId { get; set; }
        public int OutfitterId { get; set; }
        public int NationalTeamId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int FootballerValue { get; set; }


    }
}

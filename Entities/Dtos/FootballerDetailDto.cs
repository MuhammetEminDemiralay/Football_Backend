using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FootballerDetailDto : IDto
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int LeagueId { get; set; }
        public int CountryId { get; set; }
        public string FootballerImagePath { get; set; }
        public string PositionName { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int FootballerValue { get; set; }
        public int PlayerNumber { get; set; }

    }
}

using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NationalTeamDetailDto : IDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string? NationalTeamImagePath { get; set; }
        public string NationalTeamName { get; set; }
        public int NationalTeamLevel { get; set; }
        public int SquadSize { get; set; }
        public int AverageAge { get; set; }
        public int MarketValue { get; set; }
    }
}

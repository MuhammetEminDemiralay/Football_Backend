using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class NationalTeam : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int SquadSize { get; set; }
        public int AverageAge { get; set; }
        public int MarketValue { get; set; }
    }
}

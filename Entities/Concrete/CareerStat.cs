using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CareerStat : IEntity
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int Goals { get; set; }
        public int Assist { get; set; }
        public int MinutesPerGol { get; set; }
        public int MinutePlayed { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
    }
}

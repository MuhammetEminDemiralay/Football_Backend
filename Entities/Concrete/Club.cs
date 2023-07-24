using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Club : IEntity
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ClubImage { get; set; }
        public int SquadSize { get; set; }
        public int AverageAge { get; set; }
        public int NatinalTeamPlayers { get; set; }
        public int Foreigners { get; set; }
        public string StadiumName { get; set; }
        public int StaiumCapacity { get; set; }
        public int CurrentTransferRecord { get; set; }
        public int ClubMarketValue { get; set; }
    }
}

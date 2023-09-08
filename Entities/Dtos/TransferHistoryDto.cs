using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TransferHistoryDto
    {
        public int FootballerId { get; set; }
        public int Season { get; set; }
        public DateTime Joined { get; set; }
        public DateTime ContractExpires { get; set; }
        public int MarketValue { get; set; }
        public int Fee { get; set; }
        public string BeforeClubCountryImagePath { get; set; }
        public string BeforeClubImagePath { get; set; }
        public string BeforeClubName { get; set; }
        public string LastClubCountryImagePath { get; set; }
        public string LastClubImagePath { get; set; }
        public string LastClubName { get; set; }

    }
}

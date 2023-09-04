using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TransferHistory : IEntity 
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public int BeforeClubId { get; set; }
        public int LastClubId { get; set; }
        public string BeforeClubName { get; set; }
        public string LastClubName { get; set; }
        public DateTime Joined { get; set; }
        public DateTime ContractExpires { get; set; }
        public DateTime ContractExtension { get; set; }
        public int Mv { get; set; }
        public int Fee { get; set; }
    }
}

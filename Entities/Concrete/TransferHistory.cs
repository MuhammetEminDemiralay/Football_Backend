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
        public DateTime Joined { get; set; }
        public DateTime Left { get; set; }
        public int Mv { get; set; }
        public int Fee { get; set; }
    }
}

using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LeagueImage : IEntity
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string? LeagueImagePath { get; set; }
        public DateTime? Date { get; set; }
    }
}

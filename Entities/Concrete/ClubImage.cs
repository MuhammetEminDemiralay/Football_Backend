using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ClubImage : IEntity
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string? ClubImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

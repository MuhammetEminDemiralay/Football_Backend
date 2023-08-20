using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FootballerImage : IEntity
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public string FootballerImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

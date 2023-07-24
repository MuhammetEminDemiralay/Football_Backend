using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Continent : IEntity
    {
        public int Id { get; set; }
        public string ContinentName { get; set; }
    }
}

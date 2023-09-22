using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CountryImage : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CountryImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

using Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Concrete
{
    public sealed class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException(int id) : base($"The city with id : {id} could not found")
        {

        }
    }
}

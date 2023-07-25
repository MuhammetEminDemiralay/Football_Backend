using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootballerService
    {
        IDataResult<List<Footballer>> GetAll();
        IDataResult<Footballer> Get(int id);
        IResult Add(Footballer footballer);
        IResult Update(Footballer footballer);
        IResult Delete(Footballer footballer);
    }
}

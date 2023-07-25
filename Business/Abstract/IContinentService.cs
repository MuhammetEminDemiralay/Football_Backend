using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContinentService
    {
        IDataResult<List<Continent>> GetAll();
        IDataResult<Continent> Get(int id);
        IResult Add(Continent continent);
        IResult Update(Continent continent);
        IResult Delete(Continent continent);
    }
}

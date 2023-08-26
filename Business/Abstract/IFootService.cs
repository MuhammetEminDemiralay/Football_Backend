using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootService
    {
        IDataResult<List<Foot>> GetAll();
        IDataResult<Foot> Get(int id);
        IResult Add(Foot foot);
        IResult Update(Foot foot);
        IResult Delete(Foot foot);
    }
}

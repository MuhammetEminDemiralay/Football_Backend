using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILeagueService
    {
        IDataResult<List<League>> GetAll();
        IDataResult<League> Get(int id);
        IResult Add(League league);
        IResult Update(League league);
        IResult Delete(League league);
    }
}

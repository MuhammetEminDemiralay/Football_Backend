using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INationalTeamService
    {
        IDataResult<List<NationalTeam>> GetAll();
        IDataResult<NationalTeam> Get(int id);
        IResult Add(NationalTeam nationalTeam);
        IResult Update(NationalTeam nationalTeam);
        IResult Delete(NationalTeam nationalTeam);
    }
}

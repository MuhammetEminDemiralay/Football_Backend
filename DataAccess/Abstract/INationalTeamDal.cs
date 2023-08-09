using Core.DataAccess.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INationalTeamDal : IEntityRepository<NationalTeam>
    {
        List<NationalTeamDetailDto> GetNationalTeamDetailByCountryId(Expression<Func<NationalTeamDetailDto, bool>> filter = null);
    }
}

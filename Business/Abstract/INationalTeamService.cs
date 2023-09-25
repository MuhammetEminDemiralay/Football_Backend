using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INationalTeamService
    {
        Task<IDataResult<List<NationalTeam>>> GetAllAsync();
        Task<IDataResult<NationalTeam>> GetAsync(int id);
        Task<IResult> AddAsync(NationalTeam nationalTeam);
        Task<IResult> UpdateAsync(NationalTeam nationalTeam);
        Task<IResult> DeleteAsync(NationalTeam nationalTeam);

        Task<IDataResult<List<NationalTeamDetailDto>>> GetNationalTeamsDetailByCountryIdAsync(int countryId);
        Task<IDataResult<NationalTeamDetailDto>> GetNationalTeamsDetailByNationalTeamIdAsync(int nationalTeamId);

    }
}

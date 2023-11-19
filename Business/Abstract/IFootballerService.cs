using Core.RequestFeatures;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootballerService
    {
        Task<(IEnumerable<Footballer> footballer, MetaData metaData)> GetAllPaginationFootballer(FootballerParameters parameters);
        Task<IDataResult<List<Footballer>>> GetAllAsync(int minAge, int maxAge);
        Task<IDataResult<Footballer>> GetAsync(int id);
        Task<IResult> AddAsync(Footballer footballer);
        Task<IResult> UpdateAsync(Footballer footballer);
        Task<IResult> DeleteAsync(Footballer footballer);

        Task<IDataResult<List<Footballer>>> GetFootballersByClubIdAsync(int clubId);
        Task<IDataResult<List<FootballerDetailDto>>> GetFootballersDetailByClubIdAsync(int clubId);
        Task<IDataResult<FootballerDetailDto>> GetFootballerDetailByFootballerIdAsync(int footballerId);
        Task<IDataResult<List<FootballerDetailDto>>> GetFootballerDetailByCountryIdAsync(int countryId, bool nationalTeam, int nationalTeamLevel);
    }
}

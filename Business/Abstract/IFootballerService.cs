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
    public interface IFootballerService
    {
        IDataResult<List<Footballer>> GetAll();
        IDataResult<Footballer> Get(int id);
        IResult Add(Footballer footballer);
        IResult Update(Footballer footballer);
        IResult Delete(Footballer footballer);

        IDataResult<List<Footballer>> GetFootballersByClubId(int clubId);
        IDataResult<List<FootballerDetailDto>> GetFootballersDetailByClubId(int clubId);
        IDataResult<FootballerDetailDto> GetFootballerDetailByFootballerId(int footballerId);
        IDataResult<List<FootballerDetailDto>> GetFootballerDetailByCountryId(int countryId, bool nationalTeam, int nationalTeamLevel);
    }
}

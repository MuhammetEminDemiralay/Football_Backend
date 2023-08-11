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
    public interface IClubService
    {
        IDataResult<List<Club>> GetAll();
        IDataResult<Club> Get(int id);
        IResult Add(Club club);
        IResult Update(Club club);
        IResult Delete(Club club);


        IDataResult<List<ClubDetailDto>> GetClubsDetailByLeagueId(int leagueId);
    }
}

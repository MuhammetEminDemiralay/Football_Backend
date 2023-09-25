using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NationalTeamManager : INationalTeamService
    {
        INationalTeamDal _nationalTeamDal;

        public NationalTeamManager(INationalTeamDal nationalTeamDal)
        {
            _nationalTeamDal = nationalTeamDal;
        }

        public async Task<IResult> AddAsync(NationalTeam nationalTeam)
        {
            await _nationalTeamDal.AddAsync(nationalTeam);
            return new SuccessResult(Messages.NaitonalTeamAdd);
        }

        public async Task<IResult> DeleteAsync(NationalTeam nationalTeam)
        {
            await _nationalTeamDal.DeleteAsync(nationalTeam);
            return new SuccessResult(Messages.NationalTeamDelete);
        }

        public async Task<IDataResult<NationalTeam>> GetAsync(int id)
        {
            return new SuccessDataResult<NationalTeam>(await _nationalTeamDal.GetAsync(p => p.Id == id), Messages.NationalTeamGet);
        }

        public async Task<IDataResult<List<NationalTeam>>> GetAllAsync()
        {
            return new SuccessDataResult<List<NationalTeam>>(await _nationalTeamDal.GetAllAsync(), Messages.NationalTeamList);
        }

        public async Task<IDataResult<List<NationalTeamDetailDto>>> GetNationalTeamsDetailByCountryIdAsync(int countryId)
        {
            return new SuccessDataResult<List<NationalTeamDetailDto>>(await _nationalTeamDal.GetNationalTeamDetailByCountryIdAsync(p => p.CountryId == countryId), "National team detail listed....");
        }

        public async Task<IDataResult<NationalTeamDetailDto>> GetNationalTeamsDetailByNationalTeamIdAsync(int nationalTeamId)
        {
            return new SuccessDataResult<NationalTeamDetailDto>(await _nationalTeamDal.GetNationalTeamDetailByNationalTeamIdAsync(p => p.Id == nationalTeamId));
        }

        public async Task<IResult> UpdateAsync(NationalTeam nationalTeam)
        {
            await _nationalTeamDal.UpdateAsync(nationalTeam);
            return new SuccessResult(Messages.NationalTeamUpdate);
        }
    }
}

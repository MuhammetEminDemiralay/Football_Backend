using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(NationalTeam nationalTeam)
        {
            _nationalTeamDal.Add(nationalTeam);
            return new SuccessResult(Messages.NaitonalTeamAdd);
        }

        public IResult Delete(NationalTeam nationalTeam)
        {
            _nationalTeamDal.Delete(nationalTeam);
            return new SuccessResult(Messages.NationalTeamDelete);
        }

        public IDataResult<NationalTeam> Get(int id)
        {
            return new SuccessDataResult<NationalTeam>(_nationalTeamDal.Get(p => p.Id == id), Messages.NationalTeamGet);
        }

        public IDataResult<List<NationalTeam>> GetAll()
        {
            return new SuccessDataResult<List<NationalTeam>>(_nationalTeamDal.GetAll(), Messages.NationalTeamList);
        }

        public IResult Update(NationalTeam nationalTeam)
        {
            _nationalTeamDal.Update(nationalTeam);
            return new SuccessResult(Messages.NationalTeamUpdate);
        }
    }
}

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
    public class TransferHistoryManager : ITransferHistoryService
    {
        ITransferHistoryDal _transferHistoryDal;

        public TransferHistoryManager(ITransferHistoryDal transferHistoryDal)
        {
            _transferHistoryDal = transferHistoryDal;
        }

        public IResult Add(TransferHistory transferHistory)
        {
            _transferHistoryDal.Add(transferHistory);
            return new SuccessResult(Messages.TransferHistoryAdd);
        }

        public IResult Delete(TransferHistory transferHistory)
        {
            _transferHistoryDal.Delete(transferHistory);
            return new SuccessResult(Messages.TransferHistoryDelete);
        }

        public IDataResult<TransferHistory> Get(int id)
        {
            return new SuccessDataResult<TransferHistory>(_transferHistoryDal.Get(p => p.Id == id), Messages.TransferHistoryGet);
        }

        public IDataResult<List<TransferHistory>> GetAll()
        {
            return new SuccessDataResult<List<TransferHistory>>(_transferHistoryDal.GetAll(), Messages.TransferHistoryList);
        }

        public IResult Update(TransferHistory transferHistory)
        {
            _transferHistoryDal.Update(transferHistory);
            return new SuccessResult(Messages.TransferHistoryUpdate);
        }
    }
}

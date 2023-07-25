using Business.Abstract;
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
            throw new NotImplementedException();
        }

        public IResult Delete(TransferHistory transferHistory)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TransferHistory> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TransferHistory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(TransferHistory transferHistory)
        {
            throw new NotImplementedException();
        }
    }
}

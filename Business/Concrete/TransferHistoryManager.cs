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
    public class TransferHistoryManager : ITransferHistoryService
    {
        ITransferHistoryDal _transferHistoryDal;

        public TransferHistoryManager(ITransferHistoryDal transferHistoryDal)
        {
            _transferHistoryDal = transferHistoryDal;
        }

        public async Task<IResult> AddAsync(TransferHistory transferHistory)
        {
            await _transferHistoryDal.AddAsync(transferHistory);
            return new SuccessResult(Messages.TransferHistoryAdd);
        }

        public async Task<IResult> DeleteAsync(TransferHistory transferHistory)
        {
            await _transferHistoryDal.DeleteAsync(transferHistory);
            return new SuccessResult(Messages.TransferHistoryDelete);
        }

        public async Task<IDataResult<TransferHistory>> GetAsync(int id)
        {
            return new SuccessDataResult<TransferHistory>(await _transferHistoryDal.GetAsync(p => p.Id == id), Messages.TransferHistoryGet);
        }

        public async Task<IDataResult<List<TransferHistory>>> GetAllAsync()
        {
            return new SuccessDataResult<List<TransferHistory>>(await _transferHistoryDal.GetAllAsync(), Messages.TransferHistoryList);
        }

        public async Task<IDataResult<List<TransferHistoryDto>>> GetTransferHistoryByFootballerIdAsync(int footballerId)
        {
            return new SuccessDataResult<List<TransferHistoryDto>>(await _transferHistoryDal.GetFootballerTransferHistoryAsync(p => p.FootballerId == footballerId), "Futbolcu ıd sine göre transfer geçmişi getirildi");
        }

        public async Task<IResult> UpdateAsync(TransferHistory transferHistory)
        {
            await _transferHistoryDal.UpdateAsync(transferHistory);
            return new SuccessResult(Messages.TransferHistoryUpdate);
        }
    }
}

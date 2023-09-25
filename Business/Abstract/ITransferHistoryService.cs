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
    public interface ITransferHistoryService
    {
        Task<IDataResult<List<TransferHistory>>> GetAllAsync();
        Task<IDataResult<List<TransferHistoryDto>>> GetTransferHistoryByFootballerIdAsync(int footballerId);
        Task<IDataResult<TransferHistory>> GetAsync(int id);
        Task<IResult> AddAsync(TransferHistory transferHistory);
        Task<IResult> UpdateAsync(TransferHistory transferHistory);
        Task<IResult> DeleteAsync(TransferHistory transferHistory);
    }
}

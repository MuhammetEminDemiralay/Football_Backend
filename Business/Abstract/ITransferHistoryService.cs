﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransferHistoryService
    {
        IDataResult<List<TransferHistory>> GetAll();
        IDataResult<TransferHistory> Get(int id);
        IResult Add(TransferHistory transferHistory);
        IResult Update(TransferHistory transferHistory);
        IResult Delete(TransferHistory transferHistory);
    }
}
using ATM.Core.DTOs;
using ATM.Core.Entities;
using System;
using System.Collections.Generic;

namespace ATM.Core.Data
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        ICollection<TransactionDTO> GetAllTransanctions(Guid guid);
    }
}

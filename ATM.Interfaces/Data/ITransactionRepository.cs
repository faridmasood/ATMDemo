using ATM.Core.DTOs;
using ATM.Core.Entities;
using ATM.Core.Enums;
using System;
using System.Collections.Generic;

namespace ATM.Core.Data
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        ICollection<TransactionDTO> GetAllTransanctions(Guid guid);
        //  ICollection<TransactionDTO> PostTransanctions(string cardNumber, decimal amount, DateTime date, TransactionType type);
        decimal GetBalance(string cardNum);
    }
}

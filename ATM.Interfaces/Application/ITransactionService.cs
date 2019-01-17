using ATM.DataObjects.DTOs;
using ATM.DataObjects.Enums;
using System;
using System.Collections.Generic;

namespace ATM.Interfaces.Application
{
    public interface ITransactionService
    {
        void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type);
        ICollection<TransactionDTO> GetTransactions(Guid UserId, int numberOfTransactions = 5);
    }
}

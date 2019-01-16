using ATM.Entities.Enums;
using ATM.Interfaces.DTOs;
using System;
using System.Collections.Generic;

namespace ATM.Interfaces.Application
{
    interface ITransactionService
    {
        void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type);
        ICollection<TransactionDTO> GetTransactions(Guid UserId, int numberOfTransactions = 5);
    }
}

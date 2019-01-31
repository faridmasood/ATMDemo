using ATM.DataObjects.DTOs;
using ATM.DataObjects.Enums;
using ATM.Interfaces.Application;
using System;
using System.Collections.Generic;

namespace ATM.Services
{
    class TransactionService : ITransactionService
    {
        public void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type)
        {
            throw new NotImplementedException();
        }

        public ICollection<TransactionDTO> GetTransactions(Guid UserId, int numberOfTransactions = 5)
        {
            throw new NotImplementedException();
        }
    }
}

using ATM.Data;
using ATM.DataObjects.DTOs;
using ATM.DataObjects.Entities;
using ATM.DataObjects.Enums;
using ATM.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Repositories
{
    class TransactionRepository : BaseRepository<Card>, ITransactionService
    {
        public TransactionRepository(ATMDataContext context) : base(context)
        {

        }
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

using ATM.Data;
using ATM.Core.DTOs;
using ATM.Core.Entities;
using ATM.Core.Enums;
using ATM.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ATM.Repositories
{
    class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ATMDataContext context) : base(context)
        {
        }

        public ICollection<TransactionDTO> GetAllTransanctions(Guid CardId)
        {
            //var trans = DataContext.Transactions.Where(item => item.CardId == CardId);
            //return trans;
            return (from t in DataContext.Transactions
                    where t.CardId.Equals(CardId)
                    select new TransactionDTO
                    {
                        Amount = t.Amount,
                        Balance = t.Balance,
                        Card = t.Card,
                        Created = t.Created,
                        Dated = t.Dated,
                        Type = t.Type,
                        Updated = t.Updated,
                        Id = t.Id
                    }).ToList();
        }
    }
}

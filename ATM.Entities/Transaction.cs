using ATM.Entities.Enums;
using System;

namespace ATM.Entities
{
    public class Transaction : BaseEntity
    {
        public DateTime Dated { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Guid CardId { get; set; }
    }
}

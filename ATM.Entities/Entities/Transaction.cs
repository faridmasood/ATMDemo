using ATM.DataObjects.Enums;
using System;

namespace ATM.DataObjects.Entities
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

using ATM.DataObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM.DataObjects.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; }
        public string PinCode { get; set; }
        public CardType Type { get; set; }
        public CardService ServiceType { get; set; }
        public int CSV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Balance { get; set; }
        public decimal Limit { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions{ get; set; }
    }
}

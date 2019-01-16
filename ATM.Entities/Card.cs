﻿using ATM.Entities.Enums;
using System;

namespace ATM.Entities
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
    }
}

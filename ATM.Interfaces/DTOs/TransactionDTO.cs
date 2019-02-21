using ATM.Core.Entities;
using ATM.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.Core.DTOs
{
    public class TransactionDTO
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public DateTime Dated { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Guid CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}

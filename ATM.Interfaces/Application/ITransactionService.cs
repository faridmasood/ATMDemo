﻿using ATM.Core.DTOs;
using ATM.Core.Entities;
using ATM.Core.Enums;
using System;
using System.Collections.Generic;

namespace ATM.Core.Application
{
    public interface ITransactionService
    {
        void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type);
        ICollection<TransactionDTO> GetTransactions(Guid UserId, int numberOfTransactions = 5);
        ICollection<TransactionDTO> GetCardTransanctions(Guid CardId);
    }
}

﻿using ATM.Data;
using ATM.DataObjects.DTOs;
using ATM.DataObjects.Entities;
using ATM.DataObjects.Enums;
using ATM.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Repositories
{
    class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ATMDataContext context) : base(context)
        {

        }
    }
}

﻿using ATM.Core.Application;
using ATM.Core.Data;
using System;

namespace ATM.Services
{
    class DepositService : BaseServiceClass, IDepositService
    {
        public DepositService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Deposit(string cardNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

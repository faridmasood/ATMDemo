using ATM.Data;
using ATM.DataObjects.Entities;
using ATM.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Repositories
{
    class DepositRepository : BaseRepository<Card>, IDepositService
    {
        public DepositRepository(ATMDataContext context) : base(context)
        {

        }
        public void Deposit(string cardNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

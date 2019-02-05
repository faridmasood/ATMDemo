using ATM.Data;
using ATM.DataObjects.Entities;
using ATM.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Repositories
{
    class WithdrawRepository : BaseRepository<Card>, IWithdrawService
    {
        public WithdrawRepository(ATMDataContext context) : base(context)
        {

        }
        public bool Withdraw(string cardNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

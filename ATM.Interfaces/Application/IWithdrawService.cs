using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Interfaces.Application
{
    interface IWithdrawService
    {
        bool Withdraw(string cardNumber, decimal amount);
    }
}

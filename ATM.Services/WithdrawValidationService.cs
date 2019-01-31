using ATM.Interfaces.Application;
using System;

namespace ATM.Services
{
    class WithdrawValidationService : IWithdrawValidationService
    {
        public bool Validate(string cardNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

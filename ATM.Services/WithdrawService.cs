using ATM.Interfaces.Application;
using ATM.Interfaces.Data;
using System;

namespace ATM.Services
{
    class WithdrawService : BaseServiceClass, IWithdrawService
    {
        public WithdrawService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool Withdraw(string cardNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

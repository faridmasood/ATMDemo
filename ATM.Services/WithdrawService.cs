using ATM.Core.Application;
using ATM.Core.Data;
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

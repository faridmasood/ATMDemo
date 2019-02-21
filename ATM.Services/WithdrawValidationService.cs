using ATM.Core.Application;
using ATM.Core.Data;
using System;

namespace ATM.Services
{
    class WithdrawValidationService : BaseServiceClass, IWithdrawValidationService
    {
        public WithdrawValidationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool Validate(string cardNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

using ATM.Interfaces.Application;
using ATM.Interfaces.Data;
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

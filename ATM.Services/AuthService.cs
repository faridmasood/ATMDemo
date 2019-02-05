using ATM.Interfaces.Application;
using ATM.Interfaces.Data;
using System;

namespace ATM.Services
{
    class AuthService : BaseServiceClass, IAuthService
    {
        public AuthService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool Authorize(string cardNumber, string pin)
        {
            throw new NotImplementedException();
        }
    }
}

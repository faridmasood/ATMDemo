using ATM.Interfaces.Application;
using System;

namespace ATM.Services
{
    class AuthService : IAuthService
    {
        public bool Authorize(string cardNumber, string pin)
        {
            throw new NotImplementedException();
        }
    }
}

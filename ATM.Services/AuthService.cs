using ATM.Core.Entities;
using ATM.Core.Application;
using ATM.Core.Data;
using System;
using ATM.Core.Framework.Encryption;

namespace ATM.Services
{
    class AuthService : BaseServiceClass, IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashProvider _hashProvider;

        public AuthService(IUnitOfWork unitOfWork, IHashProvider hashProvider) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hashProvider = hashProvider;
        }
        public bool Authorize(string cardNumber, string pin)
        {
            var pinHash = _hashProvider.GetHash(pin);
            var card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);

            return card.PinCode == pinHash;
        }
    }
}

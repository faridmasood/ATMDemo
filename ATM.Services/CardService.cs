using System;
using ATM.Core.Application;
using ATM.Core.Data;
using ATM.Core.Entities;
using ATM.Core.Framework.Encryption;

namespace ATM.Services
{
    class CardService : BaseServiceClass, ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashProvider _hashProvider;
        public CardService(IUnitOfWork unitOfWork, IHashProvider hashProvider) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hashProvider = hashProvider;
        }

        public void ChangePin(string cardNumber, string oldPin, string newPin)
        {
            var card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);
            var _oldPin = _unitOfWork.CardRepository.GetByCardNumber(cardNumber).PinCode;
            var oldPinHash = _hashProvider.GetHash(oldPin);
            var newPinHash = _hashProvider.GetHash(newPin);

            if (_oldPin == oldPinHash)
            {
                card.PinCode = newPinHash;
                _unitOfWork.SaveChanges();
            }
        }

        public Guid GetCardId(string cardNumber)
        {
            Card card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);
            return card.Id;
        }

        public bool Verify(string cardNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}

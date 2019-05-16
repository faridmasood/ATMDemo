using System;

namespace ATM.Core.Application
{
    public interface ICardService
    {
        bool Verify(string cardNumber);
        void ChangePin(string cardNumber, string oldPin, string newPin);
        Guid GetCardId(string cardNumber);
        bool ChangeMobileNum(string cardNumber, int oldMbnum, int newMbnum);
        decimal GetCardBalance(string cardNumber);
    }
}

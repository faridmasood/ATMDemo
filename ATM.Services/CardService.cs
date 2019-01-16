using ATM.Interfaces.Application;

namespace ATM.Services
{
    class CardService : ICardService
    {
        public void ChangePin(string cardNumber, string oldPin, string newPin)
        {
            throw new System.NotImplementedException();
        }

        public bool Verify(string cardNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}

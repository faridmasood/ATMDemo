using ATM.Core.Application;
using ATM.Core.Data;

namespace ATM.Services
{
    class CardService : BaseServiceClass, ICardService
    {
        public CardService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

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

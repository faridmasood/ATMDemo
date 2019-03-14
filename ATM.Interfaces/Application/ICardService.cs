namespace ATM.Core.Application
{
    public interface ICardService
    {
        bool Verify(string cardNumber);
        void ChangePin(string cardNumber, string oldPin, string newPin);
    }
}

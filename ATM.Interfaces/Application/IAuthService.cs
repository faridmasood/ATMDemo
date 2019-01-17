namespace ATM.Interfaces.Application
{
    public interface IAuthService
    {
        bool Authorize(string cardNumber, string pin);
    }
}

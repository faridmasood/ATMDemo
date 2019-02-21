namespace ATM.Core.Application
{
    public interface IAuthService
    {
        bool Authorize(string cardNumber, string pin);
    }
}

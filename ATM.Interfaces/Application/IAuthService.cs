namespace ATM.Interfaces.Application
{
    interface IAuthService
    {
        bool Authorize(string cardNumber, string pin);
    }
}

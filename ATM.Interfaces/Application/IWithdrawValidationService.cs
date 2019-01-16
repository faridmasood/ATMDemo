namespace ATM.Interfaces.Application
{
    interface IWithdrawValidationService
    {
        bool Validate(string cardNumber, decimal amount);
    }
}

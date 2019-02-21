namespace ATM.Core.Application
{
    public interface IWithdrawValidationService
    {
        bool Validate(string cardNumber, decimal amount);
    }
}

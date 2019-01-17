namespace ATM.Interfaces.Application
{
    public interface IWithdrawValidationService
    {
        bool Validate(string cardNumber, decimal amount);
    }
}

namespace ATM.Core.Application
{
    public interface IDepositService
    {
        void Deposit(string cardNumber, decimal amount);
    }
}

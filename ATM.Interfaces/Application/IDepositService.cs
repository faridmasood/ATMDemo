namespace ATM.Interfaces.Application
{
    public interface IDepositService
    {
        void Deposit(string cardNumber, decimal amount);
    }
}

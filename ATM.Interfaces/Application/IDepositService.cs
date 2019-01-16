namespace ATM.Interfaces.Application
{
    interface IDepositService
    {
        void Deposit(string cardNumber, decimal amount);
    }
}

namespace ATM.Interfaces.Application
{
    public interface IWithdrawService
    {
        bool Withdraw(string cardNumber, decimal amount);
    }
}

namespace ATM.Core.Application
{
    public interface IWithdrawService
    {
        bool Withdraw(string cardNumber, decimal amount);
    }
}

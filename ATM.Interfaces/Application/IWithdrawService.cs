namespace ATM.Core.Application
{
    public interface IWithdrawService
    {
        void Withdraw(string cardNumber, decimal amount);
    }
}

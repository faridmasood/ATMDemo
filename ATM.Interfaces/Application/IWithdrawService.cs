using System.Threading.Tasks;

namespace ATM.Core.Application
{
    public interface IWithdrawService
    {
        Task<bool> WithdrawAsync(string cardNumber, decimal amount);
    }
}

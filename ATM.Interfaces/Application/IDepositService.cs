using System.Threading.Tasks;

namespace ATM.Core.Application
{
    public interface IDepositService
    {
        Task<bool> DepositAsync(string cardNumber, decimal amount);
    }
}

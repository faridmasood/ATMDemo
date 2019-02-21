using ATM.Core.Entities;
using System.Threading.Tasks;

namespace ATM.Core.Data
{
    public interface ICardRepository : IRepository<Card>
    {
       Card GetByCardNumber(string cardNumber);
    }
}

using System.Threading.Tasks;

namespace ATM.Core.Data
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
        ICardRepository CardRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

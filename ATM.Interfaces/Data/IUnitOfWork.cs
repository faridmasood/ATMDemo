using System.Threading.Tasks;

namespace ATM.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
        ICardRepository CardRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

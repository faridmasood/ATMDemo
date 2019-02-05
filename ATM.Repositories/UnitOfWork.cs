using ATM.Data;
using ATM.Interfaces.Data;
using System.Threading.Tasks;

namespace ATM.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ATMDataContext _dbContext;

        public UnitOfWork(ATMDataContext dbContext,
            ICardRepository cardRepository,
            ITransactionRepository transactionRepository,
            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            CardRepository = cardRepository;
            TransactionRepository = transactionRepository;
            UserRepository = userRepository;
        }

        public ICardRepository CardRepository { get; }

        public ITransactionRepository TransactionRepository { get; }

        public IUserRepository UserRepository { get; }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

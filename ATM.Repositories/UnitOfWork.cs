using ATM.Data;
using ATM.Interfaces.Data;
using System.Threading.Tasks;

namespace ATM.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ATMDataContext _dbContext;

        public UnitOfWork(ATMDataContext dbContext,
            ICardRepository cardRepository)
        {
            _dbContext = dbContext;
            CardRepository = cardRepository;
        }

        public ICardRepository CardRepository { get; }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

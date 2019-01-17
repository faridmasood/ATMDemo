using ATM.Data;
using ATM.DataObjects.Entities;
using ATM.Interfaces.Data;

namespace ATM.Repositories
{
    class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(ATMDataContext context) : base(context)
        {

        }
    }
}

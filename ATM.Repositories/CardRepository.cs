using System.Threading.Tasks;
using ATM.Data;
using ATM.Core.Entities;
using ATM.Core.Data;
using System.Linq;

namespace ATM.Repositories
{
    class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(ATMDataContext context) : base(context)
        {

        }

        public Card GetByCardNumber(string cardNumber)
        {
            var card = DataContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
            return card;
        }
    }
}

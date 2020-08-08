using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Service.CardService
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task AddCard(Card card)
        {
            await _cardRepository.Create(card);
        }
    }
}

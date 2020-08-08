using Domain.Entities;
using System.Threading.Tasks;

namespace Service.CardService
{
    public interface ICardService
    {
        Task AddCard(Card card);
    }
}

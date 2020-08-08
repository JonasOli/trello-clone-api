using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.CardService;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCard()
        {
            var card = new Card { CardType = CardType.DOING, Content = "Test123" };
            await _cardService.AddCard(card);

            return Ok();
        }
    }
}

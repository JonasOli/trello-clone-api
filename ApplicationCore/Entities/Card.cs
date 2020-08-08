using Domain.Enums;

namespace Domain.Entities
{
    public class Card : Entity
    {
        public string Content { get; set; }
        public CardType CardType { get; set; }
    }
}

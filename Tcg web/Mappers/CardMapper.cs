using Tcg_web.Dto;
using Tcg_web.Dto.Card;
using Tcg_web.Models;

namespace Tcg_web.Mappers
{
    // Mapper for Card model to CardDto
    public static class CardMapper
    {
        // Extension method to map Card to CardDto
        public static CardDto ToCardDto(this Card card)
        {
            // Map Card to CardDto
            return new CardDto
            {
                Id = card.Id,
                Name = card.Name,
                ImageUrl = card.ImageUrl,
                // Map Type
                Type = new TypeDto
                {
                    Id = card.Type?.Id ?? 0,
                    Name = card.Type?.Name ?? "Unknown"
                },
                // Map Rarity
                Rarity = new RarityDto
                {
                    Id = card.Rarity?.Id ?? 0,
                    Name = card.Rarity?.Name ?? "Unknown"
                }
            };
        }
    }
}

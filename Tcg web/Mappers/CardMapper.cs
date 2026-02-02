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
                Type = card.Type == null ? null : new TypeDto
                {
                    Id = card.Type?.Id ?? 0,
                    Name = card.Type?.Name ?? "Unknown"
                },
                // Map Rarity
                Rarity = card.Rarity == null ? null : new RarityDto
                {
                    Id = card.Rarity?.Id ?? 0,
                    Name = card.Rarity?.Name ?? "Unknown"
                },
                EnergyType = new EnergyTypeDto
                {
                    Id = card.EnergyType.Id,
                    Name = card.EnergyType.Name
                }
            };
        }

        public static TypeDto ToTypeDto(this Models.Type type)
        {
            return new TypeDto
            {
                Id = type.Id,
                Name = type.Name
            };
        }

        public static RarityDto ToRarityDto(this Rarity rarity)
        {
            return new RarityDto
            {
                Id = rarity.Id,
                Name = rarity.Name
            };
        }
        public static EnergyTypeDto ToEnergyTypeDto(this EnergyType energyType)
        {
            return new EnergyTypeDto
            {
                Id = energyType.Id,
                Name = energyType.Name
            };
        }
    }
}

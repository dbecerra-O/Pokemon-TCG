using TcgApi.Dto;
using TcgApi.Dto.Card;
using TcgApi.Models;

namespace TcgApi.Mappers
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
                    Name = card.Rarity?.Name ?? "Unknown",
                    ImageUrl = card.Rarity?.ImageUrl ?? string.Empty
                },
                EnergyType = new EnergyTypeDto
                {
                    Id = card.EnergyType.Id,
                    Name = card.EnergyType.Name,
                    ImageUrl = card.EnergyType.ImageUrl
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
                Name = rarity.Name,
                ImageUrl = rarity.ImageUrl
            };
        }
        public static EnergyTypeDto ToEnergyTypeDto(this EnergyType energyType)
        {
            return new EnergyTypeDto
            {
                Id = energyType.Id,
                Name = energyType.Name,
                ImageUrl = energyType.ImageUrl
            };
        }

        public static SetDto ToSetDto(this Set set)
        {
            return new SetDto
            {
                Id = set.Id,
                Name = set.Name,
                Price = set.Price,
                ImageUrl = set.ImageUrl
            };
        }

        public static PackageDto ToPackageDto(this Package package)
        {
            return new PackageDto
            {
                Id = package.Id,
                Name = package.Name,
                ImageUrl = package.ImageUrl,
            };
        }
    }
}

using TcgApi.Models;
using Type = TcgApi.Models.Type;

namespace TcgApi.Dto.Card
{
    // Data Transfer Object for Card entity
    public class CardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public TypeDto? Type { get; set; }
        public RarityDto? Rarity { get; set; }
        public required EnergyTypeDto EnergyType { get; set; }

    }
}

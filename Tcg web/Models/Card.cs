namespace Tcg_web.Models
{
    // Card model
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int? TypeId { get; set; }
        public int? RarityId { get; set; }
        public int EnergyTypeId { get; set; }
        public int SetId { get; set; }

        public Rarity? Rarity { get; set; }
        public Type? Type { get; set; }
        public required EnergyType EnergyType { get; set; }
        public required Set Set { get; set; }

        public ICollection<Collection> Collections { get; } = [];
    }
}

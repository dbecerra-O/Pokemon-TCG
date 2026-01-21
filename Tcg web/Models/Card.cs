namespace Tcg_web.Models
{
    // Card model
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public int RarityId { get; set; }
        public required Type Type { get; set; }
        public required Rarity Rarity { get; set; }

        public ICollection<Content> Contents { get; } = [];
        public ICollection<Collection> Collections { get; } = [];
    }
}

namespace Tcg_web.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int TypeId { get; set; }
        public int PackageId { get; set; }
        public Type Type { get; set; }
        public Rarity Rarity { get; set; }

        public ICollection<Content> Contents { get; } = new List<Content>();
        public ICollection<Collection> Collections { get; } = new List<Collection>();
    }
}

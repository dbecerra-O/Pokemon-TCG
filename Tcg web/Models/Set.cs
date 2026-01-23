namespace Tcg_web.Models
{
    // Set model
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Card> Cards { get; } = [];
        public ICollection<Package> Packages { get; } = [];
    }
}

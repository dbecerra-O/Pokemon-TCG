namespace Tcg_web.Models
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Content> Contents { get; } = new List<Content>();
        public ICollection<Package> Packages { get; } = new List<Package>();
    }
}

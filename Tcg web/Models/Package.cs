namespace Tcg_web.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        public ICollection<Content> Contents { get; } = new List<Content>();
    }
}

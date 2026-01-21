namespace Tcg_web.Models
{
    // Package model
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string ImageUrl { get; set; } = string.Empty;
        public int SetId { get; set; }
        public required Set Set { get; set; }

    }
}

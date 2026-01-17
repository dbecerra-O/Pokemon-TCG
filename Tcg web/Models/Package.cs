namespace Tcg_web.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int SetId { get; set; }
        public Set Set { get; set; }

    }
}

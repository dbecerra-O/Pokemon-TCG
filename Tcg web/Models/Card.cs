namespace Tcg_web.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Collection> Collections { get; } = new List<Collection>();
    }
}

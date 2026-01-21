namespace Tcg_web.Models
{
    // Collection model
    public class Collection
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public required User User { get; set; }
        public required Card Card { get; set; }
    }
}

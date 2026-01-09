namespace Tcg_web.Models
{
    public class Collection
    {
        public int UserId { get; set; }
        public int CardId { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public User User { get; set; }
        public Card Card { get; set; }
    }
}

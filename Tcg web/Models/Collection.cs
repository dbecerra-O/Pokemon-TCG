namespace Tcg_web.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
        public DateTime Created_at { get; set; }

        public User User { get; set; }
        public Card Card { get; set; }
    }
}

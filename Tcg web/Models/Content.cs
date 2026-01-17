namespace Tcg_web.Models
{
    public class Content
    {
        public int SetId { get; set; }
        public int CardId { get; set; }
        public Set Set { get; set; }
        public Card Card { get; set; }
    }
}

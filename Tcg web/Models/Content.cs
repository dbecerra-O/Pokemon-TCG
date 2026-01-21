namespace Tcg_web.Models
{
    // Content model
    public class Content
    {
        public int SetId { get; set; }
        public int CardId { get; set; }
        public required Set Set { get; set; }
        public required Card Card { get; set; }
    }
}

namespace Tcg_web.Models
{
    public class Content
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int CardId { get; set; }
        public Package Package { get; set; }
        public Card Card { get; set; }
    }
}

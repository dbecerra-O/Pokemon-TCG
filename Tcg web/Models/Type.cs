namespace Tcg_web.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; } = new List<Card>();
    }
}

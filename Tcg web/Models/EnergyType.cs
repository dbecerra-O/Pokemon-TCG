namespace Tcg_web.Models
{
    public class EnergyType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Card> Cards { get; } = [];
    }
}

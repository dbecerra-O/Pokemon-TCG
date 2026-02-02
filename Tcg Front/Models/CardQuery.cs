namespace TcgFront.Models
{
    public class CardQuery
    {
        public string SearchName { get; set; } = "";
        public int Type { get; set; } = 0;
        public int Rarity { get; set; } = 0;
        public int EnergyType { get; set; } = 0;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
    }
}

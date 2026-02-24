namespace TcgApi.Helpers
{
    public class QueryObject
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int Type { get; set; }
        public int Rarity { get; set; }
        public int EnergyType { get; set; }
        public string? SearchName { get; set; }
    }
}

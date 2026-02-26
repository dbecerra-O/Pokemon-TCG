namespace TcgApi.Dto.Card
{
    // Data Transfer Object for Rarity entity
    public class RarityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}

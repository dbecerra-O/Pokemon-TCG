namespace TcgWeb.Models.Dtos
{
    public class SetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}

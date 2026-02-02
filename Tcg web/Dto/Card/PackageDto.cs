namespace Tcg_web.Dto.Card
{
    // Data Transfer Object for Package entity
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}

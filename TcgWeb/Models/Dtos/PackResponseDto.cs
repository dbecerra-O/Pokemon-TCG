using TcgWeb.Models.Dtos.Card;

namespace TcgWeb.Models.Dtos
{
    public class PackResponseDto
    {
        // Data Transfer Object for response when opening a pack
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int SetId { get; set; }
        public int Cost { get; set; }
        public int NewBalance { get; set; }
        public List<CardDto> Cards { get; set; } = [];
    }
}

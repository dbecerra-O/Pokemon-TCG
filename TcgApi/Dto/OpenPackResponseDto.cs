using TcgApi.Dto.Card;

namespace TcgApi.Dto
{
    // Data Transfer Object for response when opening a pack
    public class OpenPackResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int SetId { get; set; }
        public int Cost { get; set; }
        public int NewBalance { get; set; }
        public List<CardDto> Cards { get; set; } = [];

    }
}

using Tcg_web.Dto.Card;

namespace Tcg_web.Dto
{
    // Data Transfer Object for response when opening a pack
    public class OpenPackResponseDto
    {
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
        public int SetId { get; set; }
        public int Cost { get; set; }
        public List<CardDto> cards { get; set; } = [];

    }
}

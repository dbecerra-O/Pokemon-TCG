using Tcg_web.Dto.Card;

namespace Tcg_web.Dto
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime ObtainetAt { get; set; }
        public required CardDto Card { get; set; }
    }
}

using TcgFront.Models.Dtos.Card;

namespace TcgFront.Models.Dtos
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime ObtainetAt { get; set; }
        public required CardDto Card { get; set; }
    }
}

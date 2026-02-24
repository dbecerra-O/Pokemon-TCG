using TcgWeb.Models.Dtos.Card;

namespace TcgWeb.Models.Dtos
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime ObtainetAt { get; set; }
        public required CardDto Card { get; set; }
    }
}

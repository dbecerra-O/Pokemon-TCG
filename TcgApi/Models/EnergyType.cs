using Microsoft.EntityFrameworkCore;

namespace TcgApi.Models
{
    // EnergyType entity representing the energy type of cards
    [Index(nameof(Name), IsUnique = true)]
    public class EnergyType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<Card> Cards { get; } = [];
    }
}

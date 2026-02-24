using Microsoft.EntityFrameworkCore;

namespace TcgApi.Models
{
    // Type entity representing the type of cards
    [Index(nameof(Name), IsUnique = true)]
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Card> Cards { get; } = [];
    }
}

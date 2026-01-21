using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tcg_web.Models
{
    // Rarity entity representing the rarity of cards
    [Index(nameof(Name), IsUnique = true)]
    public class Rarity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Card> Cards { get; } = [];
    }
}

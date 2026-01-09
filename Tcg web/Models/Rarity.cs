using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tcg_web.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Rarity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; } = new List<Card>();
    }
}

using Microsoft.EntityFrameworkCore;

namespace Tcg_web.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; } = new List<Card>();
    }
}

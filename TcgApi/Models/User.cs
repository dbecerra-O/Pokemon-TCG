using Microsoft.EntityFrameworkCore;

namespace TcgApi.Models
{
    // User entity representing application users
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Money { get; set; } = 1000;
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;
        public ICollection<Collection> Collections { get; set; } = new List<Collection>();
    }
}

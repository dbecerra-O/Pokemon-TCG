namespace Tcg_web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Money { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public ICollection<Collection> Collections { get; } = new List<Collection>();
    }
}

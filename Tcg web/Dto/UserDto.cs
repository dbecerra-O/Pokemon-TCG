namespace Tcg_web.Dto
{
    // Data Transfer Object for User
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Money { get; set; }
    }
}

namespace Tcg_web.Dto
{

    // Data Transfer Object for Authentication Response
    public class AuthResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}

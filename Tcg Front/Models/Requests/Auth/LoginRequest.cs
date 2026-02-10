using System.ComponentModel.DataAnnotations;

namespace TcgFront.Models.Auth
{
    public class LoginRequest
    {
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}

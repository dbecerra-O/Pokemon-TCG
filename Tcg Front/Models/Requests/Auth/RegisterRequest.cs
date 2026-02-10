using System.ComponentModel.DataAnnotations;

namespace TcgFront.Models.Auth
{
    // Model for user registration request
    public class RegisterRequest
    {
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required, MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
        public string password { get; set; } = string.Empty;
        [Compare("password", ErrorMessage = "The passwords do not match.")]
        public string confirmPassword { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace TcgFront.Models.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(8, ErrorMessage = "The Password must be at least 8 characters long.")]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

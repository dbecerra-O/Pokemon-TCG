using System.ComponentModel.DataAnnotations;

namespace TcgFront.Models.Requests
{
    public class LoginRequest
    {
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}

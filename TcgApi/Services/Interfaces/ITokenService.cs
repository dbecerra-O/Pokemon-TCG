using TcgApi.Models;

namespace TcgApi.Services.Interfaces
{
    // Service interface for Token
    public interface ITokenService
    {
        string CreateToken(User user); // Create JWT Token
    }
}

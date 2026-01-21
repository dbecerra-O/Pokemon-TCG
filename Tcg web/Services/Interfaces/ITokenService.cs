using Tcg_web.Models;

namespace Tcg_web.Services.Interfaces
{
    // Service interface for Token
    public interface ITokenService
    {
        string CreateToken(User user); // Create JWT Token
    }
}

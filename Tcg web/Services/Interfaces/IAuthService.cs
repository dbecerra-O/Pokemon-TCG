using Tcg_web.Dto.Auth;

namespace Tcg_web.Services.Interfaces
{
    // Service interface for Authentication
    public interface IAuthService
    {
        Task<AuthResponse?> RegisterAsync(RegisterDto registerDto); // Register a new user
        Task<AuthResponse?> LoginAsync(LoginDto loginDto); // Login an existing user
    }
}
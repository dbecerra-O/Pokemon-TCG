using TcgApi.Dto.Auth;

namespace TcgApi.Services.Interfaces
{
    // Service interface for Authentication
    public interface IAuthService
    {
        Task<AuthResponse?> RegisterAsync(RegisterDto registerDto); // Register a new user
        Task<AuthResponse?> LoginAsync(LoginDto loginDto); // Login an existing user
    }
}
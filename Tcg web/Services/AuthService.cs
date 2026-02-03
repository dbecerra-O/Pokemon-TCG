using Tcg_web.Dto.Auth;
using Tcg_web.Mappers;
using Tcg_web.Models;
using Tcg_web.Repository.Interfaces;
using Tcg_web.Services.Interfaces;

namespace Tcg_web.Services
{
    // Service for Authentication business logic
    public class AuthService : IAuthService
    {
        // Dependency Injection
        private readonly IUserRepository _userRepository; // User repository
        private readonly ITokenService _tokenService; // Token service
        // Constructor
        public AuthService(IUserRepository userRepository , ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        // Login user
        public async Task<AuthResponse?> LoginAsync(LoginDto loginDto)
        {
            // Get user by username
            var user = await _userRepository.GetUserByUsername(loginDto.Username);
            if (user == null)
            {
                return null;
            }

            // Verify password
            var isValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);

            if (!isValid)
            {
                return null;
            }

            var token = _tokenService.CreateToken(user);

            // return user dto
            return new AuthResponse{Token = token};
        }

        // Register user
        public async Task<AuthResponse?> RegisterAsync(RegisterDto registerDto)
        {
            if (await _userRepository.UserExists(registerDto.Username))
            {
                return null;
            }

            // Hash password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            // Create user object
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = hashedPassword,
            };

            // Save user to database
            var createdUser = await _userRepository.CreateUser(user);
            if (createdUser == null)
            {
                return null;
            }

            // Create token
            var token = _tokenService.CreateToken(createdUser);
            return new AuthResponse { Token = token };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Tcg_web.Dto.Auth;
using Tcg_web.Services.Interfaces;

namespace Tcg_web.Controllers
{
    // Controller for Authentication-related endpoints
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/Register
        [HttpPost("register")]
        [ProducesResponseType(200, Type = typeof(AuthResponse))]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = await _authService.RegisterAsync(registerDto);

            if (user == null)
            {
                return BadRequest("Registration failed");
            }
            
            return Ok(user);
        }
        
        // POST: api/auth/Login
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(AuthResponse))]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authService.LoginAsync(loginDto);
            if (user == null)
                return Unauthorized("Invalid username or password");
            return Ok(user);
        }
    }
}

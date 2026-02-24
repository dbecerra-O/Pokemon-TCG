using Microsoft.AspNetCore.Mvc;
using TcgApi.Repository.Interfaces;
using TcgApi.Mappers;
using TcgApi.Dto;
using TcgApi.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace TcgApi.Controllers
{
    // Controller for User-related endpoints
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Respository pattern implementation
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
        }

        // GET: api/User/Profile
        [HttpGet("profile")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [Authorize]
        public async Task<IActionResult?> GetProfile()
        {
            // Retrieve the username from the authenticated user
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Invalid Token");
            };

            // Fetch user details from the repository
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }

            // Map to UserDto and return
            return Ok(user.ToUserDto());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Tcg_web.Repository.Interfaces;
using Tcg_web.Mappers;
using Tcg_web.Dto;
using Tcg_web.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Tcg_web.Controllers
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

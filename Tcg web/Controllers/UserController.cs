using Microsoft.AspNetCore.Mvc;
using Tcg_web.Repository.Interfaces;
using Tcg_web.Mappers;
using Tcg_web.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Tcg_web.Controllers
{
    // Controller for User-related endpoints
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        // Respository pattern implementation
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var userDtos = users.Select(user => user.ToUserDto()).ToList();

            return Ok(userDtos);
        }

        // GET: api/User/Profile/{id}
        [HttpGet("profile/{id:int}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            var user = await _userRepository.GetProfile(id);
            
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
    }
}

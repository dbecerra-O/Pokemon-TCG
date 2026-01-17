using Microsoft.AspNetCore.Mvc;
using Tcg_web.Interfaces;
using Tcg_web.Models;
using Tcg_web;
using Microsoft.AspNetCore.Http.HttpResults;
using Tcg_web.Mappers;
using Tcg_web.Dto;

namespace Tcg_web.Controllers
{
    [Route("api/User")]
    [ApiController]
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

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userDtos);
        }

        // GET: api/User/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetUserById(id);
            
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
    }
}

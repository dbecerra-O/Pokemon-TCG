using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TcgApi.Dto;
using TcgApi.Extensions;
using TcgApi.Mappers;
using TcgApi.Repository.Interfaces;
using TcgApi.Services.Interfaces;

namespace TcgApi.Controllers
{
    [ApiController]
    [Route("api/pack")]
    public class PackController : ControllerBase
    {
        // Respository pattern implementation
        private readonly IPackService _packService;

        // Constructor with dependency injection
        public PackController(IPackService packService)
        {
            _packService = packService;    
        }

        // POST api/pack/open/{setId}
        [HttpPost("open/{setId:int}")]
        [ProducesResponseType(typeof(OpenPackResponseDto), 200)]
        [Authorize]
        public async Task<IActionResult> OpenPack([FromRoute] int setId)
        {
            try
            {
                // Retrieve the username from the authenticated user context
                var username = User.GetUsername();
                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized("User is not authenticated.");
                }
                // Call the service to purchase and open the pack
                var result = await _packService.PurchaseAndOpenPack(username, setId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Return 404 Not Found for missing resources
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request for invalid operations
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request for other exceptions
            }
        }

        [HttpGet("details")]
        [ProducesResponseType(typeof (GetPackagesDto), 200)]
        public async Task<IActionResult> GetPackDetails([FromQuery] int setId)
        {
            var packages = await _packService.PackagesDetails(setId);
            return Ok(packages);
        }
    }
}

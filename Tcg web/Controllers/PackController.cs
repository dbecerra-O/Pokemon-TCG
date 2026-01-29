using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tcg_web.Dto;
using Tcg_web.Extensions;
using Tcg_web.Mappers;
using Tcg_web.Repository.Interfaces;
using Tcg_web.Services.Interfaces;

namespace Tcg_web.Controllers
{
    [ApiController]
    [Route("api/pack")]
    public class PackController : ControllerBase
    {
        // Respository pattern implementation
        private readonly IPackService _packService;
        private readonly ICardRepository _cardRepository;

        // Constructor with dependency injection
        public PackController(ICardRepository cardRepository, IPackService packService)
        {
            _packService = packService;
            _cardRepository = cardRepository;
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
        [ProducesResponseType(200, Type = typeof(List<int>))]
        public async Task<IActionResult> GetPackDetails([FromQuery] int setId)
        {
            var packages = await _cardRepository.GetPackageBySet(setId);
            if (packages == null || packages.Count == 0)
            {
                return NotFound("No packages found for the specified set.");
            }
            var packageDtos = packages.Select(p => p.ToPackageDto());
            return Ok(packageDtos);
        }
    }
}

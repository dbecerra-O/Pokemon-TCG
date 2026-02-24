using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TcgApi.Dto;
using TcgApi.Mappers;
using TcgApi.Extensions;
using TcgApi.Repository.Interfaces;

namespace TcgApi.Controllers
{
    [ApiController]
    [Route("api/collection")]
    public class CollectionController : ControllerBase
    {
        // Respository pattern implementation
        private readonly ICollectionRepository _collectionRepository;
        public CollectionController(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        // GET: api/collection/my
        [HttpGet("my")]
        [ProducesResponseType(200, Type = typeof(List<CollectionDto>))]
        [Authorize]
        public async Task<IActionResult> GetMyCollection()
        {
            // Get the username from the JWT token
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("The user could not be identified");
            };

            // Get the user's collection from the repository
            var userCollections = await _collectionRepository.GetCollections(username);
            var collectionDto = userCollections.Select(c => c.ToCollectionDto());

            // Return the collection DTOs
            return Ok(collectionDto);
        }
    }
}

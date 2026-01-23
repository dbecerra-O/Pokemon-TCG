using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tcg_web.Dto;
using Tcg_web.Mappers;
using Tcg_web.Extensions;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Controllers
{
    [ApiController]
    [Route("api/collection")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepository;
        public CollectionController(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        [HttpGet("my")]
        [ProducesResponseType(200, Type = typeof(List<CollectionDto>))]
        [Authorize]
        public async Task<IActionResult> GetMyCollection()
        {
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("The user could not be identified");
            };

            var userCollections = await _collectionRepository.GetCollections(username);
            var collectionDto = userCollections.Select(c => c.ToCollectionDto());

            return Ok(collectionDto);
        }
    }
}

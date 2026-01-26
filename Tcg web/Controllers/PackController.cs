using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tcg_web.Extensions;
using Tcg_web.Mappers;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Controllers
{
    [ApiController]
    [Route("api/pack")]
    public class PackController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICollectionRepository _collectionRepository;

        public PackController(ICardRepository cardRepository, ICollectionRepository collectionRepository)
        {
            _cardRepository = cardRepository;
            _collectionRepository = collectionRepository;
        }

        [HttpPost("open/{setId:int}")]
        [ProducesResponseType(200, Type = typeof(List<int>))]
        [Authorize]
        public async Task<IActionResult> OpenPack([FromRoute] int setId)
        {
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var newCards = await _cardRepository.GetCards(10, setId);
            if (newCards == null || newCards.Count == 0)
            {
                return BadRequest("No cards available to draw.");
            }

            await _collectionRepository.AddCards(username, newCards);

            var cardsDto = newCards.Select(c => c.ToCardDto());

            return Ok(new
            {
                Message = "Pack opened successfully.",
                SetId = setId,
                Cards = cardsDto
            });
        }
    }
}

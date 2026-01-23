using Microsoft.AspNetCore.Mvc;
using Tcg_web.Dto.Card;
using Tcg_web.Mappers;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Controllers
{
    [ApiController]
    [Route("api/card")]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType (200, Type = typeof(List<CardDto>))]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _cardRepository.GetAllCards();
            var cardDtos = cards.Select(card => card.ToCardDto()).ToList();
            return Ok(cardDtos);
        }
    }
}

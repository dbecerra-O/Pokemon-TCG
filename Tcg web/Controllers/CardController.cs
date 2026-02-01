using Microsoft.AspNetCore.Mvc;
using Tcg_web.Dto.Card;
using Tcg_web.Helpers;
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
        public async Task<IActionResult> GetAllCards([FromQuery] QueryObject query)
        {
            var cards = await _cardRepository.GetAllCards(query);

            var cardDtos = cards.Items.Select(card => card.ToCardDto()).ToList();
            return Ok(new
            {
                Data = cardDtos,
                Meta = new
                {
                    cards.TotalCount,
                    cards.TotalPages,
                    cards.CurrentPage
                }
            });
        }
    }
}

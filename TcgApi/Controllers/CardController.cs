using Microsoft.AspNetCore.Mvc;
using TcgApi.Dto.Card;
using TcgApi.Helpers;
using TcgApi.Mappers;
using TcgApi.Repository.Interfaces;

namespace TcgApi.Controllers
{
    // Controller for Card-related endpoints
    [ApiController]
    [Route("api/card")]
    public class CardController : ControllerBase
    {
        // Dependency Injection of ICardRepository
        private readonly ICardRepository _cardRepository;
        // Constructor
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        // Endpoint to get all cards with optional query parameters for filtering and pagination
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(List<CardDto>))]
        public async Task<IActionResult> GetAllCards([FromQuery] QueryObject query)
        {
            var cards = await _cardRepository.GetAllCards(query);

            // Map to CardDto
            var cardDtos = cards.Items.Select(card => card.ToCardDto()).ToList();
            // Return response with data and metadata
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

        // Endpoint to get a list of all card types
        [HttpGet("types")]
        [ProducesResponseType(200, Type = typeof(List<TypeDto>))]
        public async Task<IActionResult> GetTypes()
        {
            var types = await _cardRepository.GetTypes();
            var typeDtos = types.Select(t => t.ToTypeDto()).ToList();
            return Ok(typeDtos);
        }

        // Endpoint to get a list of all card rarities
        [HttpGet("rarities")]
        [ProducesResponseType(200, Type = typeof(List<RarityDto>))]
        public async Task<IActionResult> GetRarities()
        {
            var rarities = await _cardRepository.GetRarities();
            var rarityDtos = rarities.Select(r => r.ToRarityDto()).ToList();
            return Ok(rarityDtos);
        }

        // Endpoint to get a list of all energy types
        [HttpGet("energytypes")]
        [ProducesResponseType(200, Type = typeof(List<EnergyTypeDto>))]
        public async Task<IActionResult> GetEnergyTypes()
        {
            var energyTypes = await _cardRepository.GetEnergyTypes();
            var energyTypeDtos = energyTypes.Select(e => e.ToEnergyTypeDto()).ToList();
            return Ok(energyTypeDtos);
        }
        // Endpoint to get a list of all card sets

        [HttpGet("sets")]
        [ProducesResponseType(200, Type = typeof(List<SetDto>))]
        public async Task<IActionResult> GetSets()
        {
            var sets = await _cardRepository.GetSets();
            var setDtos = sets.Select(s => s.ToSetDto()).ToList();
            return Ok(setDtos);
        }
    }
}

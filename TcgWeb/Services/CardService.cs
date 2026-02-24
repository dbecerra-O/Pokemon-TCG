using System.Net.Http.Json;
using TcgWeb.Models.Dtos;
using TcgWeb.Models.Dtos.Card;
using TcgWeb.Models.Requests;

namespace TcgWeb.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient;
        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CardDto>?> GetAllCards()
        {
            // Implementation to fetch all cards
            var response = await _httpClient.GetFromJsonAsync<PagedResult<CardDto>>("api/card/all");

            return response?.Data ?? new List<CardDto>();
        }

        public async Task<List<CollectionDto>?> GetUserCollection()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CollectionDto>>("api/collection/my");
            return response;
        }
    }
}

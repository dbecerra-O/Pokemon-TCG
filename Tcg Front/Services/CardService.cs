using System.Net.Http.Json;
using TcgFront.Models;

namespace TcgFront.Services
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
    }
}

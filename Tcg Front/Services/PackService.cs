using System.Net.Http.Json;
using TcgFront.Models.Dtos;

namespace TcgFront.Services
{
    public class PackService
    {
        private readonly HttpClient _httpClient;

        public PackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SetDto>?> GetAllSets()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SetDto>>("api/card/sets");
            return response;
        }
    }
}

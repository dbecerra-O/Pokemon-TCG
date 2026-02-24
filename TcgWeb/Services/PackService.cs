using System.Net.Http.Json;
using TcgWeb.Models.Dtos;
using TcgWeb.Models.Dtos.Card;

namespace TcgWeb.Services
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

        public async Task<GetPackagesDto?> GetPackDetails(int setId)
        {
            var response = await _httpClient.GetFromJsonAsync<GetPackagesDto>($"api/pack/details?setId={setId}");
            return response;
        }

        public async Task<PackResponseDto?> OpenPack(int setId)
        {
            var response = await _httpClient.PostAsync($"api/pack/open/{setId}", null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PackResponseDto>();
            }
            return new PackResponseDto { Success = false, Message = "Error al abrir el sobre." };
        }
    }
}

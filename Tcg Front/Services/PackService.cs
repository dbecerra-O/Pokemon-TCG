using System.Net.Http.Json;
using TcgFront.Models.Dtos;
using TcgFront.Models.Dtos.Card;
using static System.Net.WebRequestMethods;

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

        public async Task<List<PackageDto>> GetPackDetails(int setId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<PackageDto>>($"api/pack/details?setId={setId}");
                return response ?? new List<PackageDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo packs para el set {setId}: {ex.Message}");
                return new List<PackageDto>();
            }
        }
    }
}

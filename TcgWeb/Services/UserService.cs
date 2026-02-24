using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TcgWeb.Models.Dtos;

namespace TcgWeb.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public UserService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public UserDto? User { get; private set; }
        public event Action? onChange;

        public async Task FetchProfile()
        {
            try
            {
                var token = await _localStorage.GetItemAsStringAsync("authToken");

                if (!string.IsNullOrEmpty(token))
                {
                    token = token.Replace("\"", "").Trim();
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                    var result = await _httpClient.GetFromJsonAsync<UserDto>("api/user/profile");

                    if (result != null)
                    {
                        User = result;
                        NotifyStateChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo perfil: {ex.Message}");
            }
        }

        public void ClearProfile()
        {
            User = null;
            NotifyStateChanged();
        }

        public void NotifyStateChanged() => onChange?.Invoke();
    }
}

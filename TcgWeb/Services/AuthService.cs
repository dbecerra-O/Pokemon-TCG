using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TcgWeb.Models.Auth;
using TcgWeb.Models.Requests.Auth;

namespace TcgWeb.Services
{
    public class AuthService
    {
        // Inject HttpClient and ILocalStorageService dependencies
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly UserService _userService;
        // Constructor to initialize dependencies
        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider, UserService userService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
            _userService = userService;
        }

        // Method to register a new user
        public async Task<string?> Register(RegisterRequest request)
        {
            // Send POST request to register endpoint
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);

            // Check if the registration was successful
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<LoginResponse>(); // Read the token from the response
                await _localStorage.SetItemAsync("authToken", response?.Token); // Store the token in local storage
                await _authStateProvider.GetAuthenticationStateAsync(); // Update the authentication state
                return null; // Return null indicating success
            }

            return "Registration failed."; // Return error message if registration failed
        }

        // Method to log in an existing user
        public async Task<string?> Login(LoginRequest request)
        {
            // Send POST request to login endpoint
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);

            // Check if the login was successful
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
                await _localStorage.SetItemAsync("authToken", response?.Token); // Store the token in local storage
                await _authStateProvider.GetAuthenticationStateAsync();
                return null; // Return null indicating success
            }

            return "Login failed"; // Return error message if login failed
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken"); // Remove the token from local storage
            await _authStateProvider.GetAuthenticationStateAsync(); // Update the authentication state

        }

    }
}

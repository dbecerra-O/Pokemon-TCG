using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TcgApi.Models;
using TcgApi.Services.Interfaces;

namespace TcgApi.Services
{
    // Service for Token business logic
    public class TokenService(IConfiguration config) : ITokenService
    {
        // Create JWT Token
        public string CreateToken(User user)
        {
            // Get Token Key from appsettings.json
            var tokenKey = config["JWT:TokenKey"] ?? throw new Exception("Token Key Doesn't exist");

            // Create Symmetric Security Key
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey));

            // Create Claims
            var claims = new List<Claim>
            { 
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            // Create Signing Credentials 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); // Signing Algorithm
            // Create Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // User Claims
                Expires = DateTime.Now.AddMinutes(360), // Token valid for 6 hours
                SigningCredentials = creds, // Signing Credentials
                Issuer = config["JWT:Issuer"], // Issuer
                Audience = config["JWT:Audience"], // Audience
            };

            // Create Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();
            // Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the token as a string
            return tokenHandler.WriteToken(token);
        }
    }
}

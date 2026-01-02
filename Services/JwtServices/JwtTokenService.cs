using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Saref.Exceptions;
using Saref.Models.Client;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Saref.Services.JwtServices
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Client> _userManager;

        public JwtTokenService(IConfiguration cfg, UserManager<Client> userManager)
        {
            _configuration = cfg;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) { 
                throw new NotFoundException($"{username} not found.");
            }
            var roleUser = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, user.Name), new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), new Claim(ClaimTypes.NameIdentifier,user.Id) };
            foreach(var role in roleUser) {
                claims.AddRange(new Claim(ClaimTypes.Role,role));
            }
            var secretKey = Environment.GetEnvironmentVariable("Jwt__SecretKey");
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("JWT_SECRET_KEY", "La clave secreta no está configurada.");
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1), // El token expirará en 1 hora
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Jacaranda.Domain;
using Models = Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jacaranda.Domain.Model;

namespace Jacaranda.External.Services
{
    public class JWTService : IAuthService
    {

        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Models.Administrator Administrator)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, Administrator.Id.ToString()),
                    new Claim(ClaimTypes.Name, Administrator.Name),
                    new Claim(ClaimTypes.Role, Roles.Admin.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                Audience = "webforest.api",
                Issuer = "webforest",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateToken(Models.User User)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                    new Claim(ClaimTypes.Name, User.Name),
                    new Claim(ClaimTypes.Role, Roles.User.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                Audience = "webforest.api",
                Issuer = "webforest",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


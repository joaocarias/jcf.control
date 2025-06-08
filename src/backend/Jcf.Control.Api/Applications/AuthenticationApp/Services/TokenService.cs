using Jcf.Control.Api.Applications.AuthenticationApp.Services.IServices;
using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Core.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jcf.Control.Api.Applications.AuthenticationApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClaimsIdentity GeneratorClaims(User user)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypeConstants.USER_ID, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToUpper()),
                new Claim(ClaimTypeConstants.USER_NAME, user.Name)
            });
        }

        public string NewToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Authentication:Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GeneratorClaims(user),
                Expires = DateTime.UtcNow.AddDays(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Issuer = _configuration["Authentication:Jwt:Issuer"],
                Audience = _configuration["Authentication:Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

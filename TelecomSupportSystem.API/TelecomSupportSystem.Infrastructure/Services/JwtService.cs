using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TelecomSupportSystem.Application.Interfaces.Services;
using TelecomSupportSystem.Domain.Entities.UserAgregate;
using TelecomSupportSystem.Infrastructure.Options;

namespace TelecomSupportSystem.Infrastructure.Services
{
    public class JwtService(IOptions<JwtOptions> options) : ITokenService
    {
        private readonly JwtOptions _jwtOptions = options.Value;

        public string GenerateToken(AppUser user, string[] roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Email, user.Email!),
            };

            foreach ( var role in roles )
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

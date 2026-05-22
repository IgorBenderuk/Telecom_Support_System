using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Application.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateToken(AppUser user, string[] roles);
    }
}

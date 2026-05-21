using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Application.Mappings
{
    public static class AppUserMapping
    {
        public static AppUser ToAppUser(this RegisterRequest registerRequest)
        public static AppUser ToAppUser(this RegisterAgentRequest registerRequest)
        {
            return AppUser.Create(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email);
        }
    }
}

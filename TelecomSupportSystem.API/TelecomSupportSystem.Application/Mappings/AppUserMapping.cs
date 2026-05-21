using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Application.Mappings
{
    public static class AppUserMapping
    {
        public static AppUser ToAppUser(this RegisterCustomerRequest registerRequest)
        {
            return AppUser.Create(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email);
        }

        public static AppUser ToAppUser(this RegisterAgentRequest registerRequest)
        {
            return AppUser.Create(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email);
        }
    }
}

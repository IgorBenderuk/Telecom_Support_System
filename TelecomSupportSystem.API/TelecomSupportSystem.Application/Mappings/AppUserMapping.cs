using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Domain.Entities;

namespace TelecomSupportSystem.Application.Mappings
{
    public static class AppUserMapping
    {
        public static AppUser ToAppUser(this RegisterRequest registerRequest)
        {
            return AppUser.CreateCustomer(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email);
        }
    }
}

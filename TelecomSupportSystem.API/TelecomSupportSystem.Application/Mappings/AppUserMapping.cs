using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Domain.Entities;

namespace TelecomSupportSystem.Application.Mappings
{
    public static class AppUserMapping
    {
        public static AppUser ToAppUser(this RegisterRequest registerRequest)
        {
            return new AppUser()
            {
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                UserName = registerRequest.Email
            };
        }
    }

}

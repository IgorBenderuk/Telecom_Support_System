using Microsoft.AspNetCore.Identity;
using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Application.Interfaces;
using TelecomSupportSystem.Application.Mappings;
using TelecomSupportSystem.Domain.Common;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result> RegisterCustomerUser(RegisterRequest registerUserRequest)
        {
            var user = registerUserRequest.ToAppUser();
            var createResult = await _userManager.CreateAsync(user, registerUserRequest.Password);

            if ( !createResult.Succeeded )
            {
                return Result.Failure(string.Join(',', createResult.Errors.Select(err => err.Description)));
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, Roles.Customer);

            if ( !addRoleResult.Succeeded )
            {
                return Result.Failure(string.Join(',', addRoleResult.Errors.Select(err => err.Description)));
            }
            return Result.Success();
        }
    }
}

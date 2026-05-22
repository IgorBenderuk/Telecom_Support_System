using Microsoft.AspNetCore.Identity;
using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Application.Interfaces;
using TelecomSupportSystem.Application.Mappings;
using TelecomSupportSystem.Domain.Common;
using TelecomSupportSystem.Domain.Common.Constants;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Application.Services
{
    public class AuthService(UserManager<AppUser> userManager) : IAuthService
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        public async Task<Result> RegisterCustomer(RegisterCustomerRequest registerCustomerRequest)
        {
            var user = registerCustomerRequest.ToAppUser();
            var createResult = await _userManager.CreateAsync(user, registerCustomerRequest.Password);

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

        public async Task<Result> RegisterAgent(RegisterAgentRequest registerAgentRequest)
        {
            var user = registerAgentRequest.ToAppUser();
            var createResult = await _userManager.CreateAsync(user, registerAgentRequest.Password);

            if ( !createResult.Succeeded )
            {
                return Result.Failure(string.Join(',', createResult.Errors.Select(err => err.Description)));
            }

            user.InitializeAgentProfile();
            var updateResult = await _userManager.UpdateAsync(user);
            if ( !updateResult.Succeeded )
            {
                return Result.Failure(string.Join(',', updateResult.Errors.Select(err => err.Description)));
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, Roles.Agent);

            if ( !addRoleResult.Succeeded )
            {
                return Result.Failure(string.Join(',', addRoleResult.Errors.Select(err => err.Description)));
            }
            return Result.Success();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using TelecomSupportSystem.Application.DTOs.Auth;
using TelecomSupportSystem.Application.Interfaces.Services;
using TelecomSupportSystem.Application.Mappings;
using TelecomSupportSystem.Domain.Common;
using TelecomSupportSystem.Domain.Common.Constants;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Application.Services
{
    public class AuthService(UserManager<AppUser> userManager, ITokenService tokenService) : IAuthService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<Result> RegisterCustomer(RegisterCustomerRequest registerCustomerRequest)
        {
            var user = registerCustomerRequest.ToAppUser();
            var createResult = await _userManager.CreateAsync(user, registerCustomerRequest.Password);

            if ( !createResult.Succeeded )
            {
                return Result.Failure(createResult.Errors.Select(err => err.Description).ConcatErrors());
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, Roles.Customer);

            if ( !addRoleResult.Succeeded )
            {
                return Result.Failure(addRoleResult.Errors.Select(err => err.Description).ConcatErrors());
            }
            return Result.Success();
        }

        public async Task<Result> RegisterAgent(RegisterAgentRequest registerAgentRequest)
        {
            var user = registerAgentRequest.ToAppUser();
            var createResult = await _userManager.CreateAsync(user, registerAgentRequest.Password);

            if ( !createResult.Succeeded )
            {
                return Result.Validation(createResult.Errors.Select(err => err.Description).ConcatErrors());
            }

            user.InitializeAgentProfile();
            var updateResult = await _userManager.UpdateAsync(user);
            if ( !updateResult.Succeeded )
            {
                return Result.Failure(updateResult.Errors.Select(err => err.Description).ConcatErrors());
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, Roles.Agent);

            if ( !addRoleResult.Succeeded )
            {
                return Result.Failure(addRoleResult.Errors.Select(err => err.Description).ConcatErrors());
            }
            return Result.Success();
        }

        public async Task<Result<string>> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if ( user is null )
                return Result<string>.NotFound($"User with email{loginRequest.Email} was not found.");

            if ( !await _userManager.CheckPasswordAsync(user, loginRequest.Password) )
                return Result<string>.Failure($"Specified password is not valid.");


            var roles = await _userManager.GetRolesAsync(user);

            if ( !roles.Any() )
                throw new InvalidOperationException($"User {user.Id} has no roles assigned.");

            var token = _tokenService.GenerateToken(user, [.. roles]);

            return Result<string>.Success(token);
        }
    }
}

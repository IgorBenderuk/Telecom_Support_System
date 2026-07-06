using TelecomSupportSystem.Application.DTOs.Auth;
using TelecomSupportSystem.Domain.Common;

namespace TelecomSupportSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<Result> RegisterCustomer(RegisterCustomerRequest registerCustomerRequest);

        public Task<Result> RegisterAgent(RegisterAgentRequest registerAgentRequest);

        public Task<Result<string>> LoginAsync(LoginRequest loginRequest);
    }
}

using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Domain.Common;

namespace TelecomSupportSystem.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<Result> RegisterCustomer(RegisterCustomerRequest registerCustomerRequest);

        public Task<Result> RegisterAgent(RegisterAgentRequest registerAgentRequest);
    }
}

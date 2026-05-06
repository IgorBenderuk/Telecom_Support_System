using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Domain.Common;

namespace TelecomSupportSystem.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<Result> RegisterCustomerUser(RegisterRequest registerUserRequest);
    }
}

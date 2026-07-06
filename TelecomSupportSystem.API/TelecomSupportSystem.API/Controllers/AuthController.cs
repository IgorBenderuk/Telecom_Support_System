
using Microsoft.AspNetCore.Mvc;
using TelecomSupportSystem.Application.DTOs.Auth;
using TelecomSupportSystem.Application.Interfaces.Services;

namespace TelecomSupportSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerRequest registerRequest)
        {
            var registerResult = await _authService.RegisterCustomer(registerRequest);

            if ( !registerResult.IsSuccess )
            {
                return BadRequest(registerResult.Error);
            }
            return Ok(registerResult.IsSuccess);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginRequest loginRequest)
        {
            var loginResult = await _authService.LoginAsync(loginRequest);

            if ( !loginResult.IsSuccess )
            {
                return BadRequest(loginResult.Error);
            }
            return Ok(loginResult.Value);
        }
    }
}

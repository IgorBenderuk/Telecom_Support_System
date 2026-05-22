
using Microsoft.AspNetCore.Mvc;
using TelecomSupportSystem.Application.DTOs;
using TelecomSupportSystem.Application.Interfaces;

namespace TelecomSupportSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerRequest registerRequest)
        {
            var registerCustomerResult = await _authService.RegisterCustomer(registerRequest);

            if ( !registerCustomerResult.IsSuccess )
            {
                return BadRequest(registerCustomerResult.Error);
            }
            return Ok(registerCustomerResult.IsSuccess);
        }
    }
}

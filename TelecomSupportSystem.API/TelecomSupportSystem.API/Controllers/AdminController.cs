using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelecomSupportSystem.Application.DTOs.Auth;
using TelecomSupportSystem.Application.Interfaces.Services;
using TelecomSupportSystem.Domain.Common.Constants;

namespace TelecomSupportSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.Admin)]
    public class AdminController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register_agent")]
        public async Task<IActionResult> RegisterAgent(RegisterAgentRequest registerAgentRequest)
        {
            var registerAgentResult = await _authService.RegisterAgent(registerAgentRequest);

            if ( !registerAgentResult.IsSuccess )
            {
                return BadRequest(registerAgentResult.Error);
            }
            return Ok(registerAgentResult.IsSuccess);
        }
    }
}

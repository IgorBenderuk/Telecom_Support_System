using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelecomSupportSystem.API.Extensions;
using TelecomSupportSystem.Application.Interfaces.Services;
using TelecomSupportSystem.Domain.Common.Constants;

namespace TelecomSupportSystem.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketsController(ITicketService ticketService) : ControllerBase
    {

        [HttpPost]
        [Authorize(Roles = $"{Roles.Customer},{Roles.Admin}")]
        public async Task<IActionResult> Create([FromBody] string initialTicketDetails)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if ( userId == null )
                return Unauthorized();

            var result = await ticketService.CreateTicketAsync(initialTicketDetails, userId);

            if ( !result.IsSuccess )
            {
                return result.ToActionResult();
            }
            return CreatedAtAction(nameof(GetById), new { ticketId = result.Value }, new { ticketId = result.Value });
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetById(int ticketId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            if ( userId == null || role == null )
                return Unauthorized();

            var result = await ticketService.GetTicketByIdAsync(ticketId, userId, role);

            return result.ToActionResult();
        }

        [HttpGet("{ticketId}/messages")]
        public async Task<IActionResult> GetTicketMessages(int ticketId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            if ( userId == null || role == null )
                return Unauthorized();

            var result = await ticketService.GetMessagesByTicketIdAsync(ticketId, userId, role);
            return result.ToActionResult();
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var result = await ticketService.GetAllTicketsAsync();
            return result.ToActionResult();
        }

        [HttpPost("{ticketId}/close")]
        [Authorize(Roles = $"{Roles.Agent},{Roles.Admin}")]
        public async Task<IActionResult> Close(int ticketId)
        {
            var result = await ticketService.CloseTicket(ticketId);
            return result.ToActionResult();
        }

        [HttpDelete("{ticketId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var result = await ticketService.DeleteTicketAsync(ticketId);
            return result.ToActionResult();
        }
    }
}

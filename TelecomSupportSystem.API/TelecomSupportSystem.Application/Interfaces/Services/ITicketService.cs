using TelecomSupportSystem.Application.DTOs.Ticket;
using TelecomSupportSystem.Domain.Common;
using TelecomSupportSystem.Domain.Entities.TiketAgregate;

namespace TelecomSupportSystem.Application.Interfaces.Services
{
    public interface ITicketService
    {
        public Task<Result<int>> CreateTicketAsync(string initialTicketDetails, string customerId);
        public Task<Result<Ticket>> GetTicketByIdAsync(int ticketId, string userId, string role);

        public Task<Result<IReadOnlyCollection<MessageDto>>> GetMessagesByTicketIdAsync(int ticketId, string userId, string role);
        public Task<Result<List<Ticket>>> GetAllTicketsAsync();

        public Task<Result> DeleteTicketAsync(int ticketId);
        public Task<Result> CloseTicket(int ticketId);
    }
}

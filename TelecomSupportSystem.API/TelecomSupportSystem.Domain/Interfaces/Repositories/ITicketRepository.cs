using TelecomSupportSystem.Domain.Entities.TiketAgregation;

namespace TelecomSupportSystem.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        public Task<Ticket?> GetTicketByIdAsync(int id);
        public Task<List<Ticket>> GetTicketsAsync();
        public void AddTicket(Ticket ticket);
        public void UpdateTicket(Ticket ticket);
        public void DeleteTicket(Ticket ticket);
    }
}

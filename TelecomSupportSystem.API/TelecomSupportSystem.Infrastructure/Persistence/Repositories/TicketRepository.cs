using Microsoft.EntityFrameworkCore;
using TelecomSupportSystem.Domain.Entities.TiketAgregate;
using TelecomSupportSystem.Domain.Interfaces.Repositories;

namespace TelecomSupportSystem.Infrastructure.Persistence.Repositories
{
    public class TicketRepository(AppDbContext appDbContext) : ITicketRepository
    {
        public Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return appDbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<List<Ticket>> GetTicketsAsync()
        {
            return appDbContext.Tickets.ToListAsync();
        }

        public void AddTicket(Ticket ticket)
        {
            appDbContext.Tickets.Add(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            appDbContext.Tickets.Update(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            appDbContext.Tickets.Remove(ticket);
        }
    }
}

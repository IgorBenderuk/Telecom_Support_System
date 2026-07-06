using Microsoft.EntityFrameworkCore;
using TelecomSupportSystem.Domain.Entities.TiketAgregate;
using TelecomSupportSystem.Domain.Interfaces.Repositories;

namespace TelecomSupportSystem.Infrastructure.Persistence.Repositories
{
    public class TicketRepository(AppDbContext appDbContext) : ITicketRepository
    {
        public Task<Ticket?> GetByIdAsync(int id)
        {
            return appDbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<Ticket?> GetByIdWithMessagesAsync(int id)
        {
            return appDbContext.Tickets.Include(t => t.Messages).FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<List<Ticket>> GetAllAsync()
        {
            return appDbContext.Tickets.ToListAsync();
        }

        public void Add(Ticket ticket)
        {
            appDbContext.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            appDbContext.Tickets.Update(ticket);
        }

        public void Delete(Ticket ticket)
        {
            appDbContext.Tickets.Remove(ticket);
        }
    }
}

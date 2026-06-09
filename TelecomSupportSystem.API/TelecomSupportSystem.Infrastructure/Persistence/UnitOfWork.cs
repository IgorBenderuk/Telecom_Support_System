using TelecomSupportSystem.Domain.Interfaces;
using TelecomSupportSystem.Domain.Interfaces.Repositories;
using TelecomSupportSystem.Infrastructure.Persistence.Repositories;

namespace TelecomSupportSystem.Infrastructure.Persistence
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        private ITicketRepository _ticketRepository;

        public ITicketRepository Tickets => _ticketRepository ??= new TicketRepository(appDbContext);
        public Task SaveChangesAsync()
        {
            return appDbContext.SaveChangesAsync();
        }
    }
}

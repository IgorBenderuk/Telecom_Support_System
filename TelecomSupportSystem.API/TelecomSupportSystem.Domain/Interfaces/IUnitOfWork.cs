using TelecomSupportSystem.Domain.Interfaces.Repositories;

namespace TelecomSupportSystem.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ITicketRepository Tickets { get; }
        Task SaveChangesAsync();
    }
}

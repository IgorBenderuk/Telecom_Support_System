using TelecomSupportSystem.Domain.Entities.TiketAgregate;

namespace TelecomSupportSystem.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        public Task<Ticket?> GetByIdAsync(int id);
        public Task<Ticket?> GetByIdWithMessagesAsync(int id);
        public Task<List<Ticket>> GetAllAsync();
        public void Add(Ticket ticket);
        public void Update(Ticket ticket);
        public void Delete(Ticket ticket);
    }
}

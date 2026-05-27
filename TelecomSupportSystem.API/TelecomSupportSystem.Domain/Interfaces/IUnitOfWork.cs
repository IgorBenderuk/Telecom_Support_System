namespace TelecomSupportSystem.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}

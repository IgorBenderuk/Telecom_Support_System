namespace TelecomSupportSystem.Domain.Entities
{
    public class AppUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastActiveAt { get; set; }

        public SupportAgentProfile? AgentProfile { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

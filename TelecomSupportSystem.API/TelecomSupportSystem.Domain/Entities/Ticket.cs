using TelecomSupportSystem.Domain.Enums;

namespace TelecomSupportSystem.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public string CustomerId { get; set; }
        public AppUser Customer { get; set; }

        public string? AgentId { get; set; }
        public AppUser? Agent { get; set; }

        public Chat Chat { get; set; }
    }
}

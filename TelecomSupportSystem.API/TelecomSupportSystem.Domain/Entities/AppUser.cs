using Microsoft.AspNetCore.Identity;

namespace TelecomSupportSystem.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastActiveAt { get; set; }

        public SupportAgentProfile? AgentProfile { get; set; }
        public ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
        public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    }

    public static class Roles
    {
        public const string Agent = "Agent";
        public const string Customer = "Customer";
    }
}

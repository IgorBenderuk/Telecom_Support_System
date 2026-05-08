namespace TelecomSupportSystem.Domain.Entities
{
    public class SupportAgentProfile
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public bool IsAvailable { get; set; }
        public int TotalTicketsResolved { get; set; }
        public DateTime? LastActiveAt { get; set; }
    }
}

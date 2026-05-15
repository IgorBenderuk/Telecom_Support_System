namespace TelecomSupportSystem.Domain.Entities
{
    public class SupportAgentProfile
    {
        public string AppUserId { get; private set; }
        public AppUser AppUser { get; private set; }
        public bool IsAvailable { get; private set; }
        public int TotalTicketsResolved { get; private set; }

        private SupportAgentProfile() { }

        internal static SupportAgentProfile Create(AppUser user)
        {
            return new SupportAgentProfile
            {
                AppUserId = user.Id,
                AppUser = user,
                IsAvailable = true,
                TotalTicketsResolved = 0
            };
        }

        public void SetAvailability(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }

        public void IncrementResolvedTickets()
        {
            TotalTicketsResolved++;
        }
    }
}

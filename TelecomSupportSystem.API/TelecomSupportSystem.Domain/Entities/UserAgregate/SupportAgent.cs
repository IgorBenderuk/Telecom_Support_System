using TelecomSupportSystem.Domain.Entities.TiketAgregate;

namespace TelecomSupportSystem.Domain.Entities.UserAgregate
{
    public class SupportAgent
    {
        public string AppUserId { get; private set; }
        public AppUser AppUser { get; private set; }
        public bool IsAvailable { get; private set; }
        public int TotalTicketsResolved { get; private set; }
        public ICollection<Ticket> AssignedTickets { get; private set; } = [];
        private SupportAgent() { }

        internal static SupportAgent Create(AppUser user)
        {
            return new SupportAgent
            {
                AppUser = user,
                IsAvailable = false,
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

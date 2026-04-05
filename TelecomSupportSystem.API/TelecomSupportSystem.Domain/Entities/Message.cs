using TelecomSupportSystem.Domain.Enums;

namespace TelecomSupportSystem.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public MessageSenderType SenderType { get; set; }

        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }

        public string? SenderId { get; set; }
        public virtual AppUser? Sender { get; set; }
    }
}

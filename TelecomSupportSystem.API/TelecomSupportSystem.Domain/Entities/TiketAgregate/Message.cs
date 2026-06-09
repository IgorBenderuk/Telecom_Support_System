using TelecomSupportSystem.Domain.Common.Exeptions;
using TelecomSupportSystem.Domain.Entities.TiketAgregate.Enums;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Domain.Entities.TiketAgregate
{
    public class Message
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }
        public MessageSenderType SenderType { get; private set; }

        public int TicketId { get; private set; }
        public Ticket Ticket { get; private set; }

        public string? SenderId { get; private set; }
        public AppUser? Sender { get; private set; }

        private Message() { }
        internal static Message Create(string content, string? senderId, MessageSenderType senderType)
        {
            if ( string.IsNullOrEmpty(content) )
                throw new DomainException("content message cannot be null or empty");

            if ( senderType != MessageSenderType.AI && string.IsNullOrWhiteSpace(senderId) )
                throw new DomainException("SenderId is required for non-AI messages.");

            if ( senderType == MessageSenderType.Unknown )
                throw new DomainException("Sender type must be explicitly specified.");

            return new Message()
            {
                Content = content,
                SenderId = senderId,
                SenderType = senderType,
                SentAt = DateTime.UtcNow
            };
        }
    }
}

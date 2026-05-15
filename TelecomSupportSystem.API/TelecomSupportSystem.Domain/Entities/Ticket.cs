using TelecomSupportSystem.Domain.Enums;
using TelecomSupportSystem.Domain.Exeptions;

namespace TelecomSupportSystem.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TicketStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }

        public string CustomerId { get; private set; }
        public AppUser Customer { get; private set; }

        public string? AgentId { get; private set; }
        public AppUser? Agent { get; private set; }

        private readonly List<Message> _messages = [];
        public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();

        private Ticket() { }
        public static Ticket Create(string initialProblemDetails, string senderId)
        {
            if ( string.IsNullOrWhiteSpace(senderId) )
                throw new DomainException("CustomerId is required.");

            if ( string.IsNullOrWhiteSpace(initialProblemDetails) )
                throw new DomainException("Initial problem details are required to create new ticket.");

            var ticket = new Ticket() { CustomerId = senderId };
            ticket._messages.Add(Message.Create(initialProblemDetails, senderId, MessageSenderType.Customer));
            return ticket;
        }

        public void AddMessage(string content, MessageSenderType senderType, string? senderId = null)
        {
            if ( Status == TicketStatus.Closed )
                throw new DomainException("Cannot add message to closed ticket.");

            _messages.Add(Message.Create(content, senderId, senderType));
        }

        public void AssignAgent(string agentId)
        {
            if ( Status == TicketStatus.Closed )
                throw new DomainException("Cannot assign agent to closed ticket");

            AgentId = agentId;
            Status = TicketStatus.InProgress;
        }

        public void Close()
        {
            if ( AgentId is null )
                throw new DomainException("Cannot close ticket without assigned agent");

            if ( Status == TicketStatus.Closed )
                throw new DomainException("Ticket is already closed");

            Status = TicketStatus.Closed;
            ClosedAt = DateTime.UtcNow;
        }
    }
}

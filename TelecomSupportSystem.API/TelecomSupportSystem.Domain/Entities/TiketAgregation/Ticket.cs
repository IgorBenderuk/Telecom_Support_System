using TelecomSupportSystem.Domain.Common.Exeptions;
using TelecomSupportSystem.Domain.Entities.TiketAgregation.Enums;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Domain.Entities.TiketAgregation
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        //Should be set by ai based on chat history, that what Agent reads to understand customers problem
        public TicketStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }

        public DateTime LastChatActivity { get; private set; }
        // needed for closing ticked if timeout has expired, if expired should call Close to relieve Support agent
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
            ticket.AddMessage(initialProblemDetails, MessageSenderType.Customer, senderId);
            ticket.Status = TicketStatus.Open;
            ticket.CreatedAt = DateTime.UtcNow;
            return ticket;
        }

        public void SetAiGeneratedDescription(string title, string description)
        {
            Title = title;
            Description = description;
            Status = TicketStatus.WaitingAgent;
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

            if ( Status == TicketStatus.Resolved )
                throw new DomainException("Cannot assign agent to resolved ticket");

            if ( Status == TicketStatus.OnAgentModeration || AgentId != null )
                throw new DomainException("The agent has been already assigned to this ticket");

            AgentId = agentId;
            Status = TicketStatus.OnAgentModeration;
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

namespace TelecomSupportSystem.Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}

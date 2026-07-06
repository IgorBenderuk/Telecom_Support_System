using TelecomSupportSystem.Application.DTOs.Ticket;
using TelecomSupportSystem.Domain.Entities.TiketAgregate;

namespace TelecomSupportSystem.Application.Mappings
{
    public static class MessageMappingExtensions
    {
        public static MessageDto ToDto(this Message message) =>
            new(message.Id, message.Content, message.SenderType, message.SentAt);

        public static IReadOnlyCollection<MessageDto> ToDtoList(this IEnumerable<Message> messages) =>
            [.. messages.Select(m => m.ToDto())];
    }
}

using TelecomSupportSystem.Domain.Entities.TiketAgregate.Enums;

namespace TelecomSupportSystem.Application.DTOs.Ticket
{
    public record MessageDto(int Id, string Content, MessageSenderType SenderType, DateTime SentAt);
}

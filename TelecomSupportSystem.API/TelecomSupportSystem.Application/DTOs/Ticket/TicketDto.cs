using TelecomSupportSystem.Domain.Entities.TiketAgregate.Enums;

namespace TelecomSupportSystem.Application.DTOs.Ticket
{
    public record TicketDto(
        int Id,
        string? Title,
        string? Description,
        TicketStatus Status,
        DateTime CreatedAt
    );
}

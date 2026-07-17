using TelecomSupportSystem.Application.DTOs.Ticket;
using TelecomSupportSystem.Domain.Entities.TiketAgregate;

namespace TelecomSupportSystem.Application.Mappings
{
    public static class TicketMappingExtensions
    {
        public static TicketDto ToTicketDto(this Ticket ticket) =>
            new(ticket.Id, ticket.Title, ticket.Description, ticket.Status, ticket.CreatedAt);

        public static List<TicketDto> ToTicketDtoList(this IEnumerable<Ticket> tickets) =>
            [.. tickets.Select(x => x.ToTicketDto())];
    }
}

using Microsoft.AspNetCore.Identity;
using TelecomSupportSystem.Application.DTOs.Ticket;
using TelecomSupportSystem.Application.Interfaces.Services;
using TelecomSupportSystem.Application.Mappings;
using TelecomSupportSystem.Domain.Common;
using TelecomSupportSystem.Domain.Entities.TiketAgregate;
using TelecomSupportSystem.Domain.Entities.UserAgregate;
using TelecomSupportSystem.Domain.Interfaces;

namespace TelecomSupportSystem.Application.Services
{
    public class TicketService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager) : ITicketService
    {
        public async Task<Result<int>> CreateTicketAsync(string initialTicketDetails, string customerId)
        {
            var user = await userManager.FindByIdAsync(customerId);

            if ( user == null )
                return Result<int>.NotFound($"User with id: {customerId} was not found");

            var ticket = Ticket.Create(initialTicketDetails, user.Id);
            unitOfWork.Tickets.Add(ticket);
            await unitOfWork.SaveChangesAsync();

            return Result<int>.Success(ticket.Id);
        }

        public async Task<Result<Ticket>> GetTicketByIdAsync(int ticketId, string userId, string role)
        {
            var result = await GetTicketAsync(ticketId);

            if ( !result.IsSuccess )
                return result;

            if ( !result.Value.IsAccessibleBy(userId, role) )
                return Result<Ticket>.Forbidden("You are not allowed to access this ticket.");

            return result;
        }

        public async Task<Result<IReadOnlyCollection<MessageDto>>> GetMessagesByTicketIdAsync(int ticketId, string userId, string role)
        {

            var ticket = await unitOfWork.Tickets.GetByIdWithMessagesAsync(ticketId);
            if ( ticket == null )
                return Result<IReadOnlyCollection<MessageDto>>.NotFound($"Ticket with id:{ticketId} was not found");

            if ( !ticket.IsAccessibleBy(userId, role) )
                return Result<IReadOnlyCollection<MessageDto>>.Forbidden($"You can not access ticket with id:{ticketId}");

            var messagesDtos = ticket.Messages.ToDtoList();

            return Result<IReadOnlyCollection<MessageDto>>.Success(messagesDtos);
        }

        public async Task<Result<List<Ticket>>> GetAllTicketsAsync()
        {
            var tickets = await unitOfWork.Tickets.GetAllAsync();
            return Result<List<Ticket>>.Success(tickets);
        }
        private async Task<Result<Ticket>> GetTicketAsync(int ticketId)
        {
            var ticket = await unitOfWork.Tickets.GetByIdAsync(ticketId);

            if ( ticket == null )
                return Result<Ticket>.NotFound($"Ticket with id:{ticketId} was not found");

            return Result<Ticket>.Success(ticket);
        }

        public async Task<Result> DeleteTicketAsync(int ticketId)
        {
            var result = await GetTicketAsync(ticketId);
            if ( !result.IsSuccess )
            {
                return result;
            }
            unitOfWork.Tickets.Delete(result.Value);
            await unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> CloseTicket(int ticketId)
        {
            var result = await GetTicketAsync(ticketId);
            if ( !result.IsSuccess )
            {
                return result;
            }
            result.Value.Close();
            unitOfWork.Tickets.Update(result.Value);
            await unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}

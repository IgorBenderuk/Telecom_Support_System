using Microsoft.AspNetCore.Identity;
using TelecomSupportSystem.Domain.Common.Exeptions;
using TelecomSupportSystem.Domain.Entities.TiketAgregation;

namespace TelecomSupportSystem.Domain.Entities.UserAgregate
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastActiveAt { get; private set; }

        public SupportAgent? AgentProfile { get; private set; }
        public ICollection<Ticket> CreatedTickets { get; private set; } = [];
        public ICollection<Ticket> AssignedTickets { get; private set; } = [];

        private static AppUser CreateBase(string firstName, string lastName, string email)
        {
            if ( string.IsNullOrWhiteSpace(firstName) )
                throw new DomainException("First name is required.");
            if ( string.IsNullOrWhiteSpace(lastName) )
                throw new DomainException("Last name is required.");
            if ( string.IsNullOrWhiteSpace(email) )
                throw new DomainException("Email is required.");

            return new AppUser
            {
                CreatedAt = DateTime.UtcNow,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email
            };
        }

        public static AppUser CreateCustomer(string firstName, string lastName, string email)
        {
            return CreateBase(firstName, lastName, email);
        }

        public static AppUser CreateAgent(string firstName, string lastName, string email)
        public static AppUser CreateAdmin(string firstName, string lastName, string email)
        {
            return CreateBase(firstName, lastName, email);
        }
    }
}

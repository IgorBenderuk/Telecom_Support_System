using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TelecomSupportSystem.Domain.Entities;

namespace TelecomSupportSystem.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SupportAgentProfile> AgentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

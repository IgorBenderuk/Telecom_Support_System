using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Infrastructure.Persistence.Configurations
{
    public class SupportAgentProfileConfiguration : IEntityTypeConfiguration<SupportAgent>
    {
        public void Configure(EntityTypeBuilder<SupportAgent> builder)
        {
            builder.HasKey(s => s.AppUserId);

            builder.HasMany(u => u.AssignedTickets)
                .WithOne(t => t.Agent)
                .HasForeignKey(t => t.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.AppUser)
                .WithOne()
                .HasForeignKey<SupportAgent>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

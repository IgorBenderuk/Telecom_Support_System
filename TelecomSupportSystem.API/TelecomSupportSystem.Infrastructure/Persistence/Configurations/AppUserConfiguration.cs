using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelecomSupportSystem.Domain.Entities.UserAgregate;

namespace TelecomSupportSystem.Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);

            builder.HasOne(u => u.AgentProfile)
                .WithOne(a => a.AppUser)
                .HasForeignKey<SupportAgent>(a => a.AppUserId);

            builder.HasMany(u => u.CreatedTickets)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.AssignedTickets)
                .WithOne(t => t.Agent)
                .HasForeignKey(t => t.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

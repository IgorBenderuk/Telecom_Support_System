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

            builder.HasOne(s => s.AppUser)
                .WithOne()
                .HasForeignKey<SupportAgent>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

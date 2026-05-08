using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelecomSupportSystem.Domain.Entities;

namespace TelecomSupportSystem.Infrastructure.Persistence.Configurations
{
    public class SupportAgentProfileConfiguration : IEntityTypeConfiguration<SupportAgentProfile>
    {
        public void Configure(EntityTypeBuilder<SupportAgentProfile> builder)
        {
            builder.HasKey(s => s.AppUserId);

            builder.HasOne(s => s.AppUser)
                .WithOne()
                .HasForeignKey<SupportAgentProfile>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelecomSupportSystem.Domain.Entities;

namespace TelecomSupportSystem.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(t => t.Description).HasMaxLength(500);

            builder.HasOne(t => t.Chat)
                .WithOne(t => t.Ticket)
                .HasForeignKey<Chat>(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

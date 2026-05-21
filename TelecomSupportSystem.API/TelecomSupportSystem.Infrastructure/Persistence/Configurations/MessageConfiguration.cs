using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelecomSupportSystem.Domain.Entities.TiketAgregation;

namespace TelecomSupportSystem.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(m => m.SentAt)
                .IsRequired();

            builder.Property(m => m.SenderType)
                .IsRequired();

            builder.HasIndex(m => new { m.TicketId, m.SentAt })
                .IsDescending(false, true);

            builder.HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

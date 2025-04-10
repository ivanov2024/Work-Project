using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasKey(p => p.PaymentId);

            builder
                .Property(p => p.Amount)
                .HasDefaultValue(0m)
                .IsRequired();

            builder
                .Property(p => p.Date)
                .IsRequired();

            builder
                .Property(p => p.Status)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .IsRequired(false)
                .IsUnicode(true);

            builder
                .HasOne(p => p.SenderAccount)
                .WithMany(bk => bk.Payments)
                .HasForeignKey(p => p.SenderAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.ReceiverAccount)
                .WithMany(bk => bk.Payments)
                .HasForeignKey(p => p.ReceiverAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Transactions)
                .WithOne(t => t.Payment)
                .HasForeignKey(p => p.PaymentId);
        }
    }
}

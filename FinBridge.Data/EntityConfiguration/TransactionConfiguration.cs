using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinBridge.Data.Models;

namespace FinBridge.Data.EntityConfiguration
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .HasKey(t => t.TransactionId);

            builder
                .Property(t => t.Amount)
                .HasDefaultValue(0m)
                .IsRequired();

            builder
                .Property(t => t.TransactionType)
                .IsRequired();

            builder
               .Property(t => t.Date)
               .IsRequired();

            builder
                .HasOne(t => t.SenderAccount)
                .WithMany(bk => bk.Transactions)
                .HasForeignKey(t => t.SenderAccountId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.ReceiverAccount)
                .WithMany(bk => bk.Transactions)
                .HasForeignKey(t => t.ReceiverAccountId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CustomerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Payment)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.PaymentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Credit)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CreditId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(t => t.Note)
                .IsUnicode()
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}

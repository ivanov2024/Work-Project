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
                .WithMany(bk => bk.PaymentsAsSender)
                .HasForeignKey(t => t.SenderAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.ReceiverAccount)
                .WithMany(bk => bk.PaymentsAsReceiver)
                .HasForeignKey(t => t.ReceiverAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Credit)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CreditId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(t => t.Note)
                .IsUnicode()
                .HasMaxLength(500)
                .IsRequired(false);

            builder
                .HasMany(t => t.TransactionHistories)
                .WithOne(th => th.Transaction)
                .HasForeignKey(th => th.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

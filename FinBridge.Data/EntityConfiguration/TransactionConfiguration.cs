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
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0m);

            builder
                .HasOne(t => t.SenderAccount)
                .WithMany(ba => ba.PaymentsAsSender)
                .HasForeignKey(t => t.SenderAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.ReceiverAccount)
                .WithMany(ba => ba.PaymentsAsReceiver)
                .HasForeignKey(t => t.ReceiverAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.TransactionHistories)
                .WithOne(th => th.Transaction)
                .HasForeignKey(th => th.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

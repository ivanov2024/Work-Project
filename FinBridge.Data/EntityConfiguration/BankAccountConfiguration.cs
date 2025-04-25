using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasKey(ba => ba.BankAccountId);

            builder
                .Property(ba => ba.Balance)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(ba => ba.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(ba => ba.Bank)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(ba => ba.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ba => ba.Customer)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(ba => ba.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(ba => ba.TransactionHistories)
                .WithOne(th => th.BankAccount)
                .HasForeignKey(th => th.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(ba => ba.PaymentsAsSender)
                .WithOne(t => t.SenderAccount)
                .HasForeignKey(t => t.SenderAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(ba => ba.PaymentsAsReceiver)
                .WithOne(t => t.ReceiverAccount)
                .HasForeignKey(t => t.ReceiverAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

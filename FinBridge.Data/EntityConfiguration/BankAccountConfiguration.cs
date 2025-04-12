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
                .HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.AccountNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(b => b.Currency)
                .IsRequired();

            builder
                .Property(b => b.Balance)
                .IsRequired();

            builder
                .Property(b => b.OpenedAt)
                .IsRequired();

            builder
                .Property(b => b.IsActive)
                .IsRequired();

            builder
                .HasOne(b => b.Bank)
                .WithMany(bk => bk.BankAccounts)
                .HasForeignKey(b => b.BankId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Customer)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(b => b.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(b => b.PaymentsAsSender)
                .WithOne(t => t.SenderAccount)
                .HasForeignKey(t => t.SenderAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(b => b.PaymentsAsReceiver)
                .WithOne(t => t.ReceiverAccount)
                .HasForeignKey(t => t.ReceiverAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(bk => bk.TransactionHistories)
                .WithOne(th => th.BankAccount)
                .HasForeignKey(th => th.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

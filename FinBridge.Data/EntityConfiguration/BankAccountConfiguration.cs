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
                .HasKey(bk => bk.BankAccountId);

            builder
                .Property(bk => bk.IBAN)
                .IsRequired()
                .IsUnicode();

            builder
                .HasIndex(bk => bk.IBAN)
                .IsUnique();

            builder
                .Property(bk => bk.AccountNumber)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode();

            builder
                .HasIndex(bk => bk.AccountNumber)
                .IsUnique();

            builder
                .Property(bk => bk.CountryCode)
                .IsRequired();

            builder
                .Property(bk => bk.AccountType)
                .IsRequired();

            builder
                .HasOne(bk => bk.Bank)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(bk => bk.BankId);

            builder
                .HasOne(bk => bk.Customer)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(bk => bk.CustomerId);

            builder
                .Property(bk => bk.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(bk => bk.Balance)
                .IsRequired()
                .HasDefaultValue(0m);

            builder
                .HasMany(bk => bk.Payments)
                .WithOne(p => p.SenderAccount)
                .HasForeignKey(p => p.SenderAccountId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(bk => bk.Payments)
                .WithOne(p => p.ReceiverAccount)
                .HasForeignKey(p => p.ReceiverAccountId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(bk => bk.Transactions)
                .WithOne(t => t.SenderAccount)
                .HasForeignKey(t => t.SenderAccountId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(bk => bk.Transactions)
                .WithOne(t => t.ReceiverAccount)
                .HasForeignKey(t => t.ReceiverAccountId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

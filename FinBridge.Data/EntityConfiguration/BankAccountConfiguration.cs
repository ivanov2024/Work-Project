using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
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
                .Property(bk => bk.AccountNumber)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode();

            builder
                .Property(bk => bk.CountryCode)
                .IsRequired();

            builder
                .Property(bk => bk.AccountType)
                .IsRequired();

            builder 
                .Property(bk => bk.BankId)
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
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(3);

            builder
                .Property(bk => bk.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0m);
        }
    }
}

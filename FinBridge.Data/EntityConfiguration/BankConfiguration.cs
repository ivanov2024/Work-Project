using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    internal class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder
                .HasKey(b => b.BankId);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode();

            builder
                .Property(b => b.BankCode)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false);

            builder
                .HasIndex(b => b.BankCode)
                .IsUnique();

            builder
                .Property(b => b.CountryCode)
                .IsRequired();

            builder
                .Property(b => b.IsExisting)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .HasMany(b => b.BankAccounts)
                .WithOne(b => b.Bank)
                .HasForeignKey(b => b.BankId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

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
                .HasIndex(b => b.Name)
                .IsUnique();

            builder
                .HasIndex(b => b.BankCode)
                .IsUnique();

            builder
                .Property(b => b.IsOpenOnWeekends)
                .HasDefaultValue(true);

            builder
                .Property(b => b.IsExisting)
                .HasDefaultValue(true);

            builder
                .HasMany(b => b.BankAccounts)
                .WithOne(ba => ba.Bank)
                .HasForeignKey(ba => ba.BankId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

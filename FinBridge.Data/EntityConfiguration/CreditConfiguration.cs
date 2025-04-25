using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    internal class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder
                .HasKey(c => c.CreditId);

            builder
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Credits)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.Amount)
                .HasDefaultValue(0m);

            builder
                .Property(c => c.InterestRate)
                .HasDefaultValue(0.0m);

            builder
                .Property(c => c.TermMonths)
                .HasDefaultValue(1);

            builder
                .HasOne(c => c.Transaction)
                .WithOne(t => t.Credit)
                .HasForeignKey<Credit>(c => c.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

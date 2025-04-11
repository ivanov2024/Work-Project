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
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Property(c => c.CreditType)
                .IsRequired();

            builder
                .Property(c => c.Amount)
                .HasDefaultValue(0m)
                .IsRequired();

            builder
                .Property(c => c.InterestRate)
                .HasDefaultValue(0m)
                .IsRequired();

            builder
                .Property(c => c.TermMonths)
                .HasDefaultValue(2)
                .IsRequired();

            builder
                .ToTable(t => t.HasCheckConstraint("CK_Credit_TermMonths_Max", "[TermMonths] <= 360"));

            builder
                .Property(c => c.ApplicationDate)
                .IsRequired();

            builder
                .Property(c => c.ApprovalDate)
                .IsRequired(false);

            builder
                .Property(c => c.DisbursementDate)
                .IsRequired(false);

            builder
                .Property(c => c.Status)
                .IsRequired();

            builder
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Credit)
                .HasForeignKey(c => c.CreditId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

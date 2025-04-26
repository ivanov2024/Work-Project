using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerId);

            builder
                .HasOne(c => c.CreditScore)
                .WithOne(cs => cs.Customer)
                .HasForeignKey<CreditScore>(cs => cs.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.BankAccounts)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.Credits)
                .WithOne(cr => cr.Customer)
                .HasForeignKey(cr => cr.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Linking Customer to ApplicationUser
            builder
                .HasOne(c => c.ApplicationUser)
                .WithOne(a => a.CustomerProfile)
                .HasForeignKey<Customer>(c => c.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

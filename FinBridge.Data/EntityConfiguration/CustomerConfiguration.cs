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
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode();

            builder
                .Property(c => c.MiddleName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode();

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode();

            builder
                .Property(c => c.Email)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(c => c.Phone)
                .IsRequired();

            builder
                .Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(512);

            builder
                .Property(c => c.CreatedAt)
                .IsRequired();

            builder
                .HasMany(c => c.BankAccounts)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);

            builder
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId);

            builder
                .HasMany(c => c.Credits)
                .WithOne(cr => cr.Customer)
                .HasForeignKey(cr => cr.CustomerId);
        }
    }
}

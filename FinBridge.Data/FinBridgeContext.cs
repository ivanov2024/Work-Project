using FinBridge.Data.EntityConfiguration;
using FinBridge.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static FinBridge.Data.FinBridgeConnection;

namespace FinBridge.Data
{
    public class FinBridgeContext : IdentityDbContext<ApplicationUser>
    {
        public FinBridgeContext() { }

        public FinBridgeContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<CreditScore> CreditScores { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);


        }
    }
}
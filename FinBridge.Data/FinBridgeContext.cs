using FinBridge.Data.EntityConfiguration;
using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;

using static FinBridge.Data.FinBridgeConnection;

namespace FinBridge.Data
{
    public class FinBridgeContext : DbContext
    {
        public FinBridgeContext() { }

        public FinBridgeContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BanksAccounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<CreditScore> CreditsScores { get; set; }

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

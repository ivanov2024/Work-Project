using FinBridge.Data.Models.Enums.BankAccountEnums;

using static FinBridge.Data.Models.Generators.AccountNumberGenerator;
using static FinBridge.Data.Models.Generators.IBANGenerator;
using static FinBridge.Data.Models.Setters.CurrencySeter;

namespace FinBridge.Data.Models
{
    public class BankAccount
    {
        public Guid BankAccountId { get; set; }
            = Guid.NewGuid();

        public string IBAN { get; private set; }
            = null!;

        public string AccountNumber { get; set; }
            = null!;

        public CountryCode CountryCode { get; set; }

        public AccountType AccountType { get; set; }

        public Guid BankId { get; set; }

        public Bank Bank { get; set; }
            = null!;

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
            = null!;

        public string Currency { get; private set; }

        public decimal Balance { get; set; }
        public decimal? AccountLimit { get; set; }

        public DateTime OpenedAt { get; private set; }
            = DateTime.Now;

        public bool IsActive { get; set; }

        public DateTime? ClosetAt { get; set; }

        public ICollection<TransactionHistory> TransactionHistories { get; set; }
            = new HashSet<TransactionHistory>();
        public ICollection<Transaction> PaymentsAsSender { get; set; }
            = new HashSet<Transaction>();
        public ICollection<Transaction> PaymentsAsReceiver { get; set; }
            = new HashSet<Transaction>();

        public BankAccount() { }

        public void InitializeAccountDetails(string? currencyCode)
        {
            this.AccountNumber = GenerateAccountNumber();
            this.IBAN = GenerateIBAN(this.CountryCode.ToString(), this.Bank.BankCode, this.AccountNumber);
            this.Currency = SetCurrency(currencyCode, this.CountryCode);
        }
    }
}

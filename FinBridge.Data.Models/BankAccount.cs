using FinBridge.Data.Models.Enums.BankAccountEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static FinBridge.Data.Models.Generators.AccountNumberGenerator;
using static FinBridge.Data.Models.Generators.IBANGenerator;
using static FinBridge.Data.Models.Setters.CurrencySeter;

namespace FinBridge.Data.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        [Required]
        public string IBAN { get; private set; }
            = null!;

        [Required]
        public string AccountNumber { get; set; }
            = null!;

        [Required]
        public CountryCode CountryCode { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        [ForeignKey(nameof(Bank))]
        public int BankId { get; set; }

        public Bank Bank { get; set; }
            = null!;

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
            = null!;

        [Required]
        public string Currency { get; private set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Balance { get; set; }

        public decimal? AccountLimit { get; set; }

        [Required]
        public DateTime OpenedAt { get; private set; }
            = DateTime.Now;

        [Required]
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
            this.AccountNumber 
                = GenerateAccountNumber();
            this.IBAN 
                = GenerateIBAN(this.CountryCode.ToString(), this.Bank.BankCode, this.AccountNumber);
            this.Currency 
                = SetCurrency(currencyCode, this.CountryCode);
        }
    }
}

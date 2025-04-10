using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinBridge.Data.Models.BankAccountEnums;

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

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string Currency { get; private set; }

        public decimal Balance { get; set; }

        public ICollection<Payment> Payments { get; set; } 
            = new HashSet<Payment>();
        public ICollection<Transaction> Transactions { get; set; }
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

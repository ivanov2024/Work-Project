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
        [Key]
        public Guid BankAccountId { get; set; } 
            = Guid.NewGuid();

        [Required]
        [Unicode(true)]
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

        [Required]
        public Bank Bank { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public string Currency { get; private set; }

        [Required]
        public decimal Balance { get; set; }

        public BankAccount(string? currencyCode)
        {
            this.AccountNumber
                = GenerateAccountNumber();
            this.IBAN 
                = GenerateIBAN(this.CountryCode, this.Bank.BankCode, this.AccountNumber);
            this.Currency 
                = SetCurrency(currencyCode, this.CountryCode);
        }
    }
}

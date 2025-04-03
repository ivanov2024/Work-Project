using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinBridge.Data.Models.BankAccountEnums;

using static FinBridge.Data.Models.IBANGenerator;
using static FinBridge.Data.Models.CurrencySeter;

namespace FinBridge.Data.Models
{
    public class BankAccount
    {
        [Key]
        public Guid BankAccountId { get; set; } 
            = Guid.NewGuid();

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public string AccountNumber { get; set; }
            = null!;

        [Required]
        public CountryCode CountryCode { get; set; }

        [Required]
        [ForeignKey(nameof(Bank))]
        public Bank Bank { get; set; } 
            = null!;

        [Required]
        public string Currency { get; private set; } 
            = null!;

        [Required]
        [Unicode(true)]
        public string IBAN { get; private set; } 
            = null!;

        public BankAccount(string? currencyCode)
        {
            IBAN 
                = GenerateIBAN(CountryCode, Bank.BankCode, AccountNumber);
            Currency 
                = SetCurrency(currencyCode, CountryCode.ToString());
        }
    }
}

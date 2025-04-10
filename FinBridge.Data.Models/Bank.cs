using FinBridge.Data.Models.BankAccountEnums;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class Bank
    {
        public Guid BankId { get; set; } 
            = Guid.NewGuid();

        public string Name { get; set; } 
            = null!;

        public string BankCode { get; set; } 
            = null!;

        public CountryCode CountryCode { get; set; }

        public int BankAccountId { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } 
            = new HashSet<BankAccount>();
    }
}

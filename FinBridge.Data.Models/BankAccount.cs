using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class BankAccount
    {
        [Key]
        public Guid BankAccountId { get; set; } 
            = Guid.NewGuid();

        [Required]
        public string IBAN { get; }
            = GenerateIBAN();
    }
}

using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class TransactionHistory
    {
        [Required]
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
             = null!;

        [Required]  
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
            = null!;
    }

}

using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public decimal Amount { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class CreditScore
    {
        [Key]
        public int CreditScoreId { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; } = null!;

        [Required]
        [Range(0, 1000)]
        public int Score { get; set; }
    }
}

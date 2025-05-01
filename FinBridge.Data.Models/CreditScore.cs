using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class CreditScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreditScoreId { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } 
            = null!;

        [Required]
        [Range(0, 1000)] 
        public int Score { get; set; }
    }
}

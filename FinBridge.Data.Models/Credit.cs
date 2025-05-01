using FinBridge.Data.Models.Enums.CreditEnums;
using FinBridge.Data.Models.Enums.PaymentEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
        public class Credit
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CreditId { get; set; }

            [Required]
            [ForeignKey(nameof(Customer))]
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
                = null!;

            [Required]
            public CreditType CreditType { get; set; }

            [Required]
            [Range(0, 9999999999999999.99)]
            public decimal Amount { get; set; }

            [Required]
            [Range(0.0d, 1.0d)]
            public decimal InterestRate { get; set; }

            [Required]
            [Range(1, 360)]
            public int TermMonths { get; set; }

            [Required]
            public DateTime ApplicationDate { get; private set; } 
                = DateTime.Now;

            public DateTime? ApprovalDate { get; set; }

            public DateTime? DisbursementDate { get; set; }

            [Required]
            public PaymentStatus Status { get; set; }

            [Required]
            [ForeignKey(nameof(Transaction))]
            public int TransactionId { get; set; }
            public Transaction Transaction { get; set; } 
                = null!;
        }
}

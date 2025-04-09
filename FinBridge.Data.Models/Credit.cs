using FinBridge.Data.Models.Enums.CreditEnums;
using FinBridge.Data.Models.Enums.PaymentEnums;
using FinBridge.Data.Models.TransactionEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Credit
    {
        [Key]
        public int CreditId { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }
            = null!;

        [Required]
        public CreditType CreditType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [Required]
        public int TermMonths { get; set; }

        [Required]
        public DateTime ApplicationDate { get; private set; } 
            = DateTime.Now;

        public DateTime? ApprovalDate { get; set; }

        public DateTime? DisbursementDate { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>();
    }
}

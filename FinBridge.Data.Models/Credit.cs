using FinBridge.Data.Models.Enums.CreditEnums;
using FinBridge.Data.Models.Enums.PaymentEnums;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class Credit
    {
        public int CreditId { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
            = null!;

        public CreditType CreditType { get; set; }

        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; }

        public int TermMonths { get; set; }

        public DateTime ApplicationDate { get; private set; } 
            = DateTime.Now;

        public DateTime? ApprovalDate { get; set; }

        public DateTime? DisbursementDate { get; set; }

        public PaymentStatus Status { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>();
    }
}

using FinBridge.Data.Models.Enums.PaymentEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        public string? Description { get; set; }

        [ForeignKey(nameof(SenderAccount))]
        public int? SenderAccountId { get; set; }
        public BankAccount? SenderAccount { get; set; }

        [ForeignKey(nameof(ReceiverAccount))]
        public int? ReceiverAccountId { get; set; }
        public BankAccount? ReceiverAccount { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>(); 
    }
}

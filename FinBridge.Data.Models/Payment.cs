using FinBridge.Data.Models.Enums.PaymentEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public PaymentStatus Status { get; set; }

        public string? Description { get; set; }

        public int? SenderAccountId { get; set; }
        public BankAccount? SenderAccount { get; set; }

        public int? ReceiverAccountId { get; set; }
        public BankAccount? ReceiverAccount { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>(); 
    }
}

using FinBridge.Data.Models.Enums.TransactionEnums;

namespace FinBridge.Data.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime Date { get; set; }

        public Guid? SenderAccountId { get; set; }
        public BankAccount? SenderAccount { get; set; }

        public Guid? ReceiverAccountId { get; set; }
        public BankAccount? ReceiverAccount { get; set; }

        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? CreditId { get; set; }
        public Credit? Credit { get; set; }

        public string? Note { get; set; }
        public ICollection<TransactionHistory> TransactionHistories { get; set; }
            = new HashSet<TransactionHistory>();
    }
}

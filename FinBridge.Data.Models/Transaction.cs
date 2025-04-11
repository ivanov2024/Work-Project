using FinBridge.Data.Models.TransactionEnums;

namespace FinBridge.Data.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime Date { get; set; }

        public int? SenderAccountId { get; set; }
        public BankAccount? SenderAccount { get; set; }

        public int? ReceiverAccountId { get; set; }
        public BankAccount? ReceiverAccount { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public int? CreditId { get; set; }
        public Credit? Credit { get; set; }

        public string? Note { get; set; }
    }
}

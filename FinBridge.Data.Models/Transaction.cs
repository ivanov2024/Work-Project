using FinBridge.Data.Models.TransactionEnums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(SenderAccount))]
        public int? SenderAccountId { get; set; }
        public BankAccount? SenderAccount { get; set; }

        [ForeignKey(nameof(ReceiverAccount))]
        public int? ReceiverAccountId { get; set; }
        public BankAccount? ReceiverAccount { get; set; }

        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Unicode(true)]
        [MaxLength(500)]
        public string? Note { get; set; }
    }
}

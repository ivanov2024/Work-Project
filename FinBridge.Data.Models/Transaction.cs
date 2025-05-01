using FinBridge.Data.Models.Enums.TransactionEnums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey(nameof(SenderAccount))]
        public int SenderAccountId { get; set; }
        public BankAccount SenderAccount { get; set; } 
            = null!;

        [Required]
        [ForeignKey(nameof(ReceiverAccount))]
        public int ReceiverAccountId { get; set; }
        public BankAccount ReceiverAccount { get; set; }
            = null!;

        [ForeignKey(nameof(Credit))]
        public int? CreditId { get; set; }
        public Credit? Credit { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
            = null!;

        [StringLength(500, MinimumLength = 0)]
        [Unicode(true)]
        public string? Note { get; set; }

        public ICollection<TransactionHistory> TransactionHistories { get; set; }
            = new HashSet<TransactionHistory>();
    }
}

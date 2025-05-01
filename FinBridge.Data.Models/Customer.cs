using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } 
            = null!;

        [ForeignKey(nameof(CreditScore))]
        public int? CreditScoreId { get; set; }
        public CreditScore? CreditScore { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } 
            = new HashSet<BankAccount>();
        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>();
        public ICollection<Credit> Credits { get; set; } 
            = new HashSet<Credit>();
    }
}

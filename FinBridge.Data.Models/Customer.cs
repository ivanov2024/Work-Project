using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
            = Guid.NewGuid();

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string FirstName { get; set; }
            = null!;

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string MiddleName { get; set; }
            = null!;

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string LastName { get; set; }
            = null!;

        [Required]
        [Unicode(false)]
        [EmailAddress]
        public string Email { get; set; }
            = null!;

        [Required]
        [Phone]
        public string Phone { get; set; }
            = null!;

        [Required]
        public DateTime CreatedAt { get; } 
            = DateTime.Now;

        public ICollection<BankAccount> BankAccounts { get; set; }
            = new HashSet<BankAccount>();
        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>();
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static FinBridge.Data.Models.Setters.PasswordSetter;

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
        [MaxLength(512)]
        public string Password { get; private set; }
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
        public ICollection<Credit> Credits { get; set; }
            = new HashSet<Credit>();

        public Customer(string password)
        {
            this.Password
                = SetPassword(password);
        }
    }
}

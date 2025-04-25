using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static FinBridge.Data.Models.Setters.PasswordSetter;

namespace FinBridge.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 3)]
        [Unicode(false)]
        public string FirstName { get; set; }
            = null!;

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 3)]
        [Unicode(false)]
        public string MiddleName { get; set; }
            = null!;

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 3)]
        [Unicode(false)]
        public string LastName { get; set; }
            = null!;

        [Required]
        public string Username { get; private set; }
            = null!;

        [Required]
        [StringLength(maximumLength: 320, MinimumLength = 4)]
        [Unicode(false)]
        public string Email { get; set; }
            = null!;

        [Required]
        [RegularExpression(@"^.{6,}$")]
        public string Password { get; private set; }
            = null!;

        [RegularExpression(@"^\d{7,15}$")]
        public string Phone { get; set; }
            = null!;

        [Required]
        public DateTime CreatedAt { get; }
            = DateTime.Now;

        [Required]
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(CreditScore))]
        public int? CreditScoreId { get; set; }
        public CreditScore? CreditScore { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
            = new HashSet<BankAccount>();
        public virtual ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>();
        public virtual ICollection<Credit> Credits { get; set; }
            = new HashSet<Credit>();

        public Customer() { }

        public Customer(string password)
        {
            this.Password
                = SetPassword(password);
            this.Username
                = $"{this.FirstName} {this.LastName}";
        }
    }
}

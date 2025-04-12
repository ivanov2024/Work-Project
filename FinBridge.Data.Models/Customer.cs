using static FinBridge.Data.Models.Setters.PasswordSetter;

namespace FinBridge.Data.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
            = Guid.NewGuid();

        public string FirstName { get; set; }
            = null!;

        public string MiddleName { get; set; }
            = null!;

        public string LastName { get; set; }
            = null!;

        public string Email { get; set; }
            = null!;

        public string Password { get; private set; }
            = null!;

        public string Phone { get; set; }
            = null!;

        public DateTime CreatedAt { get; } 
            = DateTime.Now;

        public bool IsDeleted { get; set; }

        public int? CreditScoreId { get; set; }
        public CreditScore? CreditScore { get; set; }

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

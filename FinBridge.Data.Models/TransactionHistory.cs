namespace FinBridge.Data.Models
{
    public class TransactionHistory
    {
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
             = null!;

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
            = null!;
    }

}

namespace FinBridge.Data.Models
{
    public class CreditScore
    {
        public int CreditScoreId { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public int Score { get; set; }
    }
}

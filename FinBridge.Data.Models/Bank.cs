using FinBridge.Data.Models.Enums.BankAccountEnums;

namespace FinBridge.Data.Models
{
    public class Bank
    {
        public Guid BankId { get; set; }
            = Guid.NewGuid();

        public string Name { get; set; }
            = null!;

        public string BankCode { get; set; }
            = null!;

        public CountryCode CountryCode { get; set; }

        public string Location { get; set; }
            = null!;

        public string Phone { get; set; }
            = null!;

        public string WorkingHours { get; set; }
            = null!;

        public bool IsOpenOnWeekends { get; set; }

        public bool IsExisting { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
            = new HashSet<BankAccount>();
    }
}

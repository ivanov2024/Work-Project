using FinBridge.Data.Models.Enums.BankAccountEnums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBridge.Data.Models
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        [Unicode(true)]
        public string Name { get; set; }
            = null!;

        [Required]
        [RegularExpression(@"^(\d{5}|[A-Z0-9]{6}|[A-Z]{6}\d{2}[A-Z0-9]{0,3}|\d{9}|[A-Z]{4}0[A-Z0-9]{6})$")]
        public string BankCode { get; set; }
            = null!;

        [Required]
        public CountryCode CountryCode { get; set; }
        
        [Required]
        [StringLength(170, MinimumLength = 1)]
        public string Location { get; set; }
            = null!;

        [Required]
        [RegularExpression(@"^(\+[\d]{1,3}[-. ]?)?[\d]{3,}[-. ]?[\d]{3,}[-. ]?[\d]{3,}(\s*(ext|x|\.)\s*\d{2,5})?$")]
        public string Phone { get; set; }
            = null!;

        [Required]
        public string WorkingHours { get; set; }
            = null!;

        [Required]
        public bool IsOpenOnWeekends { get; set; }

        [Required]
        public bool IsExisting { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
            = new HashSet<BankAccount>();
    }
}

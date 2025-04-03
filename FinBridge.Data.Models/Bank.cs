using FinBridge.Data.Models.BankAccountEnums;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class Bank
    {
        [Key]
        public Guid BankId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(70)]
        public string Name { get; set; } 
            = null!;

        [Required]
        public string BankCode { get; set; } =
            null!;

        [Required]
        public CountryCode CountryCode { get; set; }
    }
}

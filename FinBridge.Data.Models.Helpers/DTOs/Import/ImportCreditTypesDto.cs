using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models.Helpers.DTOs.Import
{
    public class ImportCreditTypesDto
    {
        [Required]
        [JsonProperty(nameof(CreditType))]
        public string CreditType { get; set; }
            = null!;

        [Required]
        [JsonProperty(nameof(Code))]
        public string Code { get; set; }
            = null!;
    }
}

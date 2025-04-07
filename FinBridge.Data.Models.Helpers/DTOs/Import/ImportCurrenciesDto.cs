using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models.Helpers.DTOs.Import
{
    public class ImportCurrenciesDto
    {
        [Required]
        [JsonProperty(nameof(Code))]
        public string Code { get; set; }
            = null!;

        [Required]
        [JsonProperty(nameof(Currency))]
        public string Currency { get; set; }
            = null!;
    }
}

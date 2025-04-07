using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models.Helpers.DTOs.Import
{
    public class ImportTransactionTypesDto
    {
        [Required]
        [JsonProperty(nameof(TransactionType))]
        public string TransactionType { get; set; }
            = null!;

        [Required]
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }
            = null!;
    }
}

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models.Helpers.DTOs.Import
{
    public class ImportPaymentStatusesDto
    {
        [Required]
        [JsonProperty(nameof(Status))]
        public string Status { get; set; }
            = null!;

        [Required]
        [JsonProperty(nameof(Code))]
        public string Code { get; set; }
            = null!;
    }
}

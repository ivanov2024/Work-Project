using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models.Helpers.DTOs.Import
{
    public class ImportAccountTypesDto
    {
        [Required]
        [JsonProperty(nameof(Code))]
        public string Code {  get; set; }
            = null!;

        [Required]
        [JsonProperty(nameof(Type))]
        public string Type { get; set; }
            = null!;
    }
}

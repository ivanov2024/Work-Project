using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models.Helpers.DTOs.Import
{
    public class ImportCountriesDto
    {
        [Required]
        [JsonProperty(nameof(Code))]
        public string Code { get; set; }
            = null!;

        [Required]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
            = null!;
    }
}

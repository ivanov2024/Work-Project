using System.ComponentModel.DataAnnotations;

namespace FinBridge.App.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл формат.")]
        public string Email { get; set; } 
            = null!;

        [Required(ErrorMessage = "Паролата е задължителна.")]
        [MinLength(6, ErrorMessage = "Паролата трябва да съдържа поне 6 символа.")]
        public string Password { get; set; } 
            = null!;

        public bool RememberMe { get; set; }
            = false;
    }

}

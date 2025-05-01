using System.ComponentModel.DataAnnotations;

namespace FinBridge.App.Models
{
    public class RegisterRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } 
            = null!;

        [Required, MinLength(6)]
        public string Password { get; set; } 
            = null!;

        [Required]
        [Compare("Password", ErrorMessage = "Паролите са несъвместими!")]
        public string ConfirmPassword { get; set; } 
            = null!;

        [Required]
        public string FirstName { get; set; } 
            = null!;

        [Required]
        public string LastName { get; set; } 
            = null!;

        [Required]
        public string MiddleName { get; set; } 
            = null!;
    }
}

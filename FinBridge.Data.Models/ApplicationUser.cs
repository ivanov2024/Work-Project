using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinBridge.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 3)]
        [Unicode(true)]
        public string FirstName { get; set; } 
            = null!;

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 3)]
        [Unicode(true)]
        public string MiddleName { get; set; } 
            = null!;

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 3)]
        [Unicode(true)]
        public string LastName { get; set; } 
            = null!;

        [Required]
        public DateTime CreatedAt { get; set; } 
            = DateTime.UtcNow;

        [Required]
        public bool IsDeleted { get; set; } 
            = false;

        // Navigation property: Optional one-to-one relationship with Customer
        public Customer? CustomerProfile { get; set; }
    }
}

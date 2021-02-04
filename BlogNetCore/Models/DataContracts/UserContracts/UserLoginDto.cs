using System.ComponentModel.DataAnnotations;

namespace BlogNetCore.Models.DataContracts.UserContracts
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

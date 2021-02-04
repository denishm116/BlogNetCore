using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogNetCore.Models.DataContracts.UserContracts
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

       
    }
}
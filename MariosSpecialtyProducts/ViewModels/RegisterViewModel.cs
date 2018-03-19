using System;
using MariosSpecialtyProducts.Models;
using System.ComponentModel.DataAnnotations;

namespace MariosSpecialtyProducts.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(
            100,
            ErrorMessage = "The password must be at least {2} characters long, a capital letter, a digit, and a special character.",
            MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

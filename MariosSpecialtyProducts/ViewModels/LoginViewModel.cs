using System;
using MariosSpecialtyProducts.Models;
using System.ComponentModel.DataAnnotations;

namespace MariosSpecialtyProducts.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

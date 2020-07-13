using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models
{
    public class RegisterModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name= "Username ")]
        [Required(ErrorMessage = "Please create a username ")]
        
        public string Username { get; set; }

        [Display(Name = "Password ")]
        [Required(ErrorMessage = "Please create a password")]
        [StringLength(20 ,MinimumLength = 3, ErrorMessage = "Your password much be have a at least 4 character")]
        public string Password { get; set; }
        [Display(Name = "Pasword confirm  ")]
        [Compare("Password", ErrorMessage = " Password confirmation doesn't match ")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Yor email ")]
        [Required(ErrorMessage = "Please retype the email address.")]
        public string Email { get; set; }

        [Display(Name = "Number phone ")]
        public string Phone { get; set; }
    }
}
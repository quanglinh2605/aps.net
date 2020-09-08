using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Display(Name = "Ten")]
        public string FirstName { get; set; }

        [Display(Name = "Ho")]
        public string LastName { get; set; }

        [Display(Name = "Ngay sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Hom thu")]
        public string Email { get; set; }

        [Display(Name = "So dien thoai")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tai khoan")]
        public string UserName { get; set; }

        [Display(Name = "Mat khau")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xac nhan mat khau")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}

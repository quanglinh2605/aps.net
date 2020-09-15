using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class UserVm
    {
        public int Id { get; set; }

        [Display(Name = "Ten")]
        public string FirstName { get; set; }

        [Display(Name = "Ho")]
        public string LastName { get; set; }

        [Display(Name = "So dien thoai")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tai khoan")]
        public string UserName { get; set; }

        [Display(Name = "Hom thu")]
        public string Email { get; set; }

        [Display(Name = "Ngay sinh")]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; } 
    }
}

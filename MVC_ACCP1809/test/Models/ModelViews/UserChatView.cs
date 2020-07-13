using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models.ModelViews
{
    public class UserChatView
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter your name")]
        [StringLength(maximumLength:100)]
        [DataType(DataType.Text)]
        [Display(Name="Ten nguoi dung")]
        public string Name { get; set; }

        [StringLength(maximumLength:20)]
        [Required(ErrorMessage ="Please enter nick name")]
        [MaxLength(ErrorMessage ="over size")]
        [DataType(DataType.Text)]
        [Display(Name = "Nick nguoi dung")]
        public string nick { get; set; }

        [Required(ErrorMessage = "Please Enter your name")]
        [StringLength(maximumLength: 15)]
        [MaxLength(ErrorMessage = "over size")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string pwd { get; set; }

        public bool active { get; set; }

        [EmailAddress(ErrorMessage = "Email is invalid")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Hinh anh")]
        public string avatar { get; set; }
    }
}
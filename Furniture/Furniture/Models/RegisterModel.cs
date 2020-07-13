using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Furniture.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        public string CaptchaCode { get; set; }

        [Display(Name = "Ten dang nhap")]
        [Required(ErrorMessage ="Yeu cau dang nhap ten dang nhap")]
        public string Username { get; set; }

        [Display(Name = "Mat khau")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Do dai mat khau it nhat la 6")]
        [Required(ErrorMessage = "Yeu cau nhap mat khau")]
        public string Password { get; set; }

        [Display(Name="Xac nhan mat khau")]
        [Compare("Password", ErrorMessage = "Xac nhan mat khau khong dung.")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Ho ten")]
        [Required(ErrorMessage ="Yeu cau dang nhap ho ten")]
        public string Name { get; set; }

        [Display(Name ="Dia chi")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Yeu cau nhap Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yeu cau nhap so dien thoai")]
        public string Phone { get; set; }
    }
}
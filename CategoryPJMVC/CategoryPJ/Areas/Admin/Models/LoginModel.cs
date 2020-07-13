using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CategoryPJ.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Moi nhap lai username") ]
        public string UserName { set; get; }
        [Required(ErrorMessage =  "Moi nhap lai password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
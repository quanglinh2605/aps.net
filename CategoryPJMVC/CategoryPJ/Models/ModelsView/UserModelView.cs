using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models.ModelsView
{
    public class UserModelView
    {
        public int ID { get; set; }
        [Display(Name =" Username")]
        [Required(ErrorMessage = "You forgot enter username")]
        public string Username { get; set; }
        [Display(Name = " Password")]
        [Required(ErrorMessage = "You forgot enter password")]
        public string Password { get; set; }
        public bool isSubcrise { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
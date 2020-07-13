using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models.ModelsView
{
    public class CustomerModelView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
    }
}
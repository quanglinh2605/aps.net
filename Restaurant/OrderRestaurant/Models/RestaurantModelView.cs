using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderRestaurant.Models
{
    public class RestaurantModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
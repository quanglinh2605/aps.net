using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderRestaurant.Models
{
    public class DetailMenu
    {
        public MenuModelView Menu { get; set; }
        public int quantity { get; set; }
        public int Cus_Id {get;set;}
    }
}
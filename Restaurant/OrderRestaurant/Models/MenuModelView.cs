using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrderRestaurant.Models
{
    public class MenuModelView
    {
        public int Id { get; set; }
        public int Res_Id { get; set; }
        [DisplayName("Upload File")]
        public string ImgPath { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
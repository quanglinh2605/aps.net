using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models.ModelsView
{
    public class TableModelView
    {
        public int Id { get; set; }
        public int Res_ID { get; set; }
        public string Name { get; set; }
        public int NumberSeat { get; set; }
        public bool Status { get; set; }
    }
}
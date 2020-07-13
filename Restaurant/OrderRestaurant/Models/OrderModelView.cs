using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderRestaurant.Models
{
    public class OrderModelView
    {
        public TimeSpan timeStart { get; set; }
        public string Menu { get; set; }
        public string choosetable { get; set; }
        public string status { get; set; }
        public int numberSeat { get; set; }
        public int Id { get; set; }
        public int Id_Customer { get; set; }
        public int Id_Res { get; set; }
        public bool OrderStatus { get; set; }
    }
}
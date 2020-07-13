//------------------------------------------------------------------------------
// auto-generated
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// /auto-generated
//------------------------------------------------------------------------------

namespace RestaurantAPI.Models.ModelsData
{
    using System;
    using System.Collections.Generic;
    
    public partial class checkOrder
    {
        public System.TimeSpan timeStart { get; set; }
        public string Menu { get; set; }
        public string choosetable { get; set; }
        public string status { get; set; }
        public int numberSeat { get; set; }
        public int Id { get; set; }
        public int Id_Customer { get; set; }
        public int Id_Res { get; set; }
        public bool OrderStatus { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        public virtual customer customer1 { get; set; }
    }
}

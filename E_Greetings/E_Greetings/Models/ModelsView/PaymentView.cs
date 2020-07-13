using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Greetings.Models.ModelsView
{
    public class PaymentView
    {
        public int ID { get; set; }
        public int IDMem { get; set; }
        public string StartDate { get; set; }
        public string endDate { get; set; }
        public decimal Price { get; set; }
        public bool status { get; set; }
    }
}
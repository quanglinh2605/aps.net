using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CategoryPJ.Models.ModelsView
{
    public class SendMailView
    {
        public int ID { get; set; }
        public int IDtemp_user { get; set; }
        public string Sendby { get; set; }
        public List<string> Receiver { get; set; }
        public string SendDate { get; set; }
        public string Message { get; set; }
       
    }
}
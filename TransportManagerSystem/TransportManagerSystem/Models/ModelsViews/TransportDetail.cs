using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportManagerSystem.Models.ModelsViews
{
    public class TransportDetail
    {
        public int Id { get; set; }
        public int Transport_id { get; set; }
        public int Owner_id { get; set; }
        public int Account_id { get; set; }
        public int Region_Id { get; set; }
        public int transType_Id { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public bool Status { get; set; }
    }
}
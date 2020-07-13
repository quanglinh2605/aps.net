using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportManagerSystem.Models.ModelsViews
{
    public class OwnerDetail
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Id_Card { get; set; }
    }
}
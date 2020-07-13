using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportManagerSystem.Models.ModelsViews
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public int usertype_id { get; set; }
        public int Regional_Id { get; set; }
        public bool Status { get; set; }
    }
}
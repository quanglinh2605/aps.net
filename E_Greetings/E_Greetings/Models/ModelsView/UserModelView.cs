using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Greetings.Models.ModelsView
{
    public class UserModelView
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isSubcrise { get; set; }
    }
}
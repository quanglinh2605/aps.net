using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryPJ
{
    [Serializable]
    public class CurrentUser
    {
        public int UserID { get; set; }
        public string Username { get; set; }
    }
}
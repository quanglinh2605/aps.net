using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models.ModelsView
{
    public class template_userView
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public int IDTemp { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public HttpPostedFileBase FilePhoto { get; set; }
        public string PathPhoto { get; set; }
        public HttpPostedFileBase FileMusic { get; set; }
        public string PathMusic { get; set; }
    }
}
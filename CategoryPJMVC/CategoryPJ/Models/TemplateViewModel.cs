using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models
{
    public class TemplateViewModel
    {
        public int ID { get; set; }
        public Nullable<int> IDCategory { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }

        public virtual Category Category { get; set; }

        public string Occasions { get; set; }
    }
}
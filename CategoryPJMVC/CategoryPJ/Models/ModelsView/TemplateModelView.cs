using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models.ModelsView
{
    public class TemplateModelView
    {
        public int ID { get; set; }
        public int IDCategory { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set;}
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
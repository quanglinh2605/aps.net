using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models.DAO
{
    public class CategoryDAO
    {
        public class Category
        {
            public int ID { get; set; }
            public string Occasions { get; set; }

        }
        public class Template
        {
            public int ID { get; set; }
            public Nullable<int> IDCategory { get; set; }
            public string Title { get; set; }
            public string Descriptions { get; set; }
        }

        static void Main(string[] args)
        {
            heheEntities db = new heheEntities();
            var query = (from c in db.Categories
                         join t in db.Templates on c.ID equals t.IDCategory
                         select new
                         {
                             c.Occasions,
                             t.Title,
                             t.Descriptions
                         });
            Console.WriteLine("Occasions \t Title \t Descriptions \t");
            foreach (var item in query)
            {
                Console.WriteLine(item.Occasions + "\t\t" + item.Title + "\t\t" + item.Descriptions + "\t\t");
            }
            Console.ReadLine();
        }

        internal object ViewDetail(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
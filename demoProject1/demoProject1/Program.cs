using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            models.Dept d = new models.Dept { DName = "Kinh doanh", loc = "Ho Chi Minh" };
            models.baitap2Entities en = new models.baitap2Entities();
            en.Depts.Add(d);
            en.SaveChanges();
        } 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoProject1
{
    class Class1
    {
        static void Main(String[] args)
        {
            String x="";
            List<string> ls = new List<string>();
            while (x.ToLower() != ("x"))
            {
                ls.Add(x);
                Console.WriteLine("nhap: ");
                x = Console.ReadLine();
            } 
            string output = Console.ReadLine();
            //List<string> kq = ls.Where(d => d.Contains(output)).ToList();
            foreach(string item in ls)
            {
                if (item.Contains(output))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

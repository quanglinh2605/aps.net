using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 { 
    class compareClass<T>
{
    public bool compare(T x, T y)
    {
        if (x.Equals(y))
            return true;
        else return false;
    }
}
class Program
{
    static void Main(string[] args)
    {
        compareClass<int> obj = new compareClass<int>();
        bool result = obj.compare(5, 6);
        Console.WriteLine("result: " + result);
    }
}
}


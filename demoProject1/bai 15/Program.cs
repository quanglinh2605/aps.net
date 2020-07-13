using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_15
{
    class Toanhoc
    {
        public int tongso(int s1, int s2)
        {
            return s1 + s2;
        }
        public void luythua(int n,int value,out int result)
        {
            result = 1;
            for(int i = 0; i < n; i++)
            {
                result = value * result;
            }
        }
        public static void swap(ref int s1,ref int s2)
        {
            int t;
            t = s1;
            s1 = s2;
            s2 = t;
        }
    }
    delegate int Ham(int x, int y);
    internal class Program
    {
        static void Main(string[] args)
        {
            Toanhoc th = new Toanhoc();
            Ham Ham1 = new Ham(th.tongso);
            Ham ham2 = new Ham(th.luythua);
            Ham ham3 = new Ham(Toanhoc.swap);
        }
    }
}
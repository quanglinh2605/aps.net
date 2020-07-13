using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoWinform.Helper
{
    public sealed class MyMath
    {
        private MyMath()
        {

        }
        public static int Add(int param1, int param2)
        {
            return param1 + param2;
        }
        public static int Sub(int param1, int param2)
        {
            return param1 - param2;
        }
        public static int Mul(int param1, int param2)
        {
            return param1 * param2;
        }
        public static int Div(int param1, int param2)
        {
            if (param2 == 0) return 0;
            return param1 / param2;
        }
    }
   
}

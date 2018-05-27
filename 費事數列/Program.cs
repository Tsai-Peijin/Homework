using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 費事數列
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 46;
            int i = 0;
            int[] fs = new int[N];
            fs[0] = 1;
            fs[1] = 1;
            for (i = 0; i < N; i++)
            {
                if (i == 0 | i == 1)
                { Console.WriteLine(fs[i]); }

                else
                {
                    Console.WriteLine((fs[i] = fs[i - 1] + fs[i - 2]));
                }
            }
            Console.ReadLine();
        }
    }
}

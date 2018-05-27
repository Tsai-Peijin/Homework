using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_猴子找大王
{
    class Program
    {
        // 猴子有100隻，每3隻踢1隻出去，直到剩最後一人

        static void Main(string[] args)
        {
            int i;
            Console.Write("有幾隻猴子：");
            string input= Console.ReadLine();
            i = int.Parse(input);
            
            int j;
            Console.Write("數到第幾隻猴子要淘汰：");
            string inputs = Console.ReadLine();
            j = int.Parse(inputs);

            Program M = new Program();
            Console.WriteLine("第 " + M.King(i, j) + " 隻是大王");
            Console.ReadLine();
        }

        public int King(int monkey,int n)
        {
            int k = 0;
            for(int i = 2; i <= monkey; i++)
            
                k = (k + n) % i;
                return k += 1;
        }
    }
}

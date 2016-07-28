using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            while(a<10)
            {
                a++;
                int b = a+1;
                Console.WriteLine(b);
            }
            Console.ReadKey();
        }
    }
}

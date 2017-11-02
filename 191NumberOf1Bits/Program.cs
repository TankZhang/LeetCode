using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/number-of-1-bits/description/
namespace _191NumberOf1Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(HammingWeight(15));
            Console.ReadKey();
        }

        static int HammingWeight(uint n)
        {
            uint result = 0;
            do
            {
                result += (n%2);
            } while ((n/=2)!=0);
            return (int)result;
        }
    }
}

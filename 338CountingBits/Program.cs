using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/counting-bits/description/  
namespace _338CountingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in CountBits(5))
            {
                Console.Write("{0},",item);
            }
            Console.ReadKey();
        }
        static  int[] CountBits(int num)
        {
            int[] result = new int[num + 1];
            for (int i = 1; i <= num; i++)
            {
                result[i] = result[i / 2] + i % 2;
            }
            return result;
        }
    }
}

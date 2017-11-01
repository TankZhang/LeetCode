using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
//https://leetcode.com/problems/number-complement/description/

namespace _476NumberComplement
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(FindComplement(Convert.ToInt32(input)));
            Console.ReadKey();
        }

        static int FindComplement(int num)
        {
            int result = 0;
            Stack<int> bStack = new Stack<int>();
            int yu = 0;
            while (num != 0)
            {
                yu = num % 2;
                bStack.Push(yu);
                num /= 2;
            }
            while (bStack.Count != 0)
            {
                result += (int)((1-bStack.Pop())*Math.Pow(2,bStack.Count));
            }
            return result;
        }
    }
}

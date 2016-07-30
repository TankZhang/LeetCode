using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/single-number/
namespace _136SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 6, 8, 6, 3, 1 };
            Console.WriteLine(SingleNumber(nums));
            Console.ReadKey();
        }
        static int SingleNumber(int[] nums)
        {
            int temp = 0; ;
            foreach (int item in nums)
            {
                temp ^= item;
            }
            return temp;
        }
    }
}

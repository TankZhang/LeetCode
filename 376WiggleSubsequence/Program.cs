using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/wiggle-subsequence/
namespace _376WiggleSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 };
            Console.WriteLine(WiggleMaxLength(nums));
            Console.ReadKey();
        }
        static int WiggleMaxLength(int[] nums)
        {
            if (nums.Length < 3||nums.Distinct().Count()<2) return nums.Distinct().Count();
            int n = 0;
            int count = 2;
            while (nums[n + 1] == nums[n])
                n++;
            int flag = nums[n + 1] > nums[n] ? 1 : -1;
            for (int i = n+2; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    continue;
                if((nums[i]>nums[i-1]?1:-1)*flag<0)
                {
                    count++;flag *= -1;
                }
            }
            return count;
        }
    }
}

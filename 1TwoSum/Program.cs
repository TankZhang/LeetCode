using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/two-sum/
namespace _1TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {3,2,4};
            int target = 6;
            int[] result = TwoSum(nums, target);
            Console.WriteLine("{0}  {1}", result[0], result[1]);
            Console.ReadKey();

        }

        static int[] TwoSum(int[] nums, int target)
        {
            int[] returns=new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if(nums[i]+nums[j]==target)
                    {
                        returns[0] = i;
                        returns[1] = j;
                        return returns;
                    }
                }
            }
            return returns;
        }
    }
}

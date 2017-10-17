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
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;
            int[] result = TwoSum2(nums, target);
            Console.WriteLine("{0}  {1}", result[0], result[1]);
            Console.WriteLine("Hello world!");
            Console.ReadKey();

        }

        static int[] TwoSum(int[] nums, int target)
        {
            int[] returns = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        returns[0] = i;
                        returns[1] = j;
                        return returns;
                    }
                }
            }
            return returns;
        }

        //网上时间复杂度为O(n)的解法
        static int[] TwoSum2(int[] nums, int target)
        {
            int[] returns = new int[2];
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    returns[0] = dic[nums[i]];
                    returns[1] = i;
                    return returns;
                }
                if (dic.ContainsKey(target - nums[i]))
                {
                    if (2 * (target - nums[i]) == target)
                    {
                        returns[0] = dic[nums[i]];
                        returns[1] = i;
                        return returns;

                    }
                }
                else
                {
                    dic.Add(target - nums[i], i);
                }
            }
            return returns;
        }


    }
}

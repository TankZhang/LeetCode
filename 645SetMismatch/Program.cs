using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/set-mismatch/description/
namespace _645SetMismatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ret = FindErrorNums2(new int[] { 2,2 });
            Console.WriteLine("{0}/{1}", ret[0], ret[1]);
            Console.ReadKey();
        }

        //reference
        static int[] FindErrorNums2(int[] nums)
        {
            int l = nums.Length;
            int[] ans = new int[2];
            int[] count = new int[l];
            for (int i = 0; i < l; i++)
            {
                ans[1] ^= (i + 1) ^ nums[i];
                if (++count[nums[i] - 1] == 2)
                    ans[0] = nums[i];
            }
            ans[1] ^= ans[0];
            return ans;
        }


        //so bad ,so ugly,so complex...
        static int[] FindErrorNums(int[] nums)
        {
            int[] ret = new int[2] { 0, 1 };
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                    ret[0] = nums[i];
                if (nums[i + 1] - nums[i] > 1)
                    ret[1] = nums[i + 1] - 1;
                if (i == nums.Length - 2&&ret[1]==1&&nums[i+1]!=i+2)
                    ret[1] = i + 2;
            }
            return ret;
        }
    }
}

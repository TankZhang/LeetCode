using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given an array of size n, find the majority element.The majority element is the element that appears more than ⌊ n/2 ⌋ times.
//You may assume that the array is non-empty and the majority element always exist in the array.
namespace _169MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1,1,1,1,1,1,1,85,1,1,74,1,1,1,2,5,6,3,8,4,9,7,78 };
            Console.WriteLine(Solution.MajorityElement(nums));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public static int MajorityElement(int[] nums)
        {
            int j = nums[0];
            int k = 1;
            Func<int, int> get = x => { j = nums[x]; return 1; };
            for (int i = 1; i < nums.Length; i++)
            {
                k = nums[i] == j ? k + 1 : (k == 0 ?get(k) : k - 1);
            }
            return j;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/combination-sum-iii/
namespace _216CombinationSumIII
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<List<int>> l = CombinationSum3(3, 9);

            foreach (IList<int> item1 in l)
            {
                foreach (var item in item1)
                {
                    Console.Write("{0}  ", item);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static IList<List<int>> CombinationSum3(int k, int n)
        {
            List<List<int>> l = new List<List<int>>();
            //if (n > (9 - k + 1 + 9) * k / 2 || n < (1 + k) * k / 2 || k > 9) return l;
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> lTemp = new List<int>();
            Go(l,  lTemp,nums, k, n, 0);
            return l;
        }

        private static void Go(List<List<int>> l, List<int> lTemp, int[] nums, int k, int target, int start)
        {
            if (target == 0 && k == 0)
            { l.Add(new List<int>(lTemp)); }
            else
            {
                for (int i = start; i < nums.Length && target > 0 && k > 0; i++)
                {
                    lTemp.Add(nums[i]);
                    Go(l, lTemp, nums, k - 1, target - nums[i], i + 1);
                    lTemp.RemoveAt(lTemp.Count - 1);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/permutations/
namespace _46Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1,2,3 };
            IList<IList<int>> l = Permute(nums);
            foreach (List<int> l1 in l)
            {
                foreach (int item in l1)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> l = new List<IList<int>>();
            if (nums.Length == 0)
                return l;
            if (nums.Length == 1)
            {
                l.Add(new List<int>() { nums[0] });
                return l;
            }
            if (nums.Length > 1)
            {
                l.Add(new List<int>() { nums[0] });
                l = Go(l,nums,nums.Length,1);
                return l;
            }
            return l;
        }

        private static IList<IList<int>> Go(IList<IList<int>> l, int[] nums, int length, int level)
        {
            if (level == length)
                return l;
            else
            {
                int times = level + 1;
                l = Copy(l, times,nums[level]);
                return Go(l, nums, length, level+1);
            }
        }

        private static IList<IList<int>> Copy(IList<IList<int>> l, int times,int addn)
        {
            int n = l.Count;
            for (int i = 1; i < times; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    List<int> temp = new List<int>(l[j]);
                    try { temp.Insert(i, addn); }
                    catch { temp.Add(addn); }
                    l.Add(temp);
                }
            }

            for (int j = 0; j < n; j++)
            {
                l[j].Insert(0,addn);
            }
            return l;
        }
    }
}

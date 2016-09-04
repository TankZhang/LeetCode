using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/missing-number/
namespace _268MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();
            for (int i = 0; i < 20; i++)
                l.Add(i);
            l.RemoveAt(16);
            int[] nums = l.ToArray();
            Console.WriteLine(MissingNumber(nums));
            Console.ReadKey();
        }
        static int MissingNumber(int[] nums)
        {
            Array.Sort(nums);
            int l = 0, h = nums.Length - 1;
            if (h == -1)
                return 0;
            if (nums[h] == h)
                return h + 1;
            int m;
            while (l < h)
            {
                m = (l + h) / 2;
                if (nums[m] == m)
                    l = m + 1;
                else
                    h = m;
            }
            return l;
        }
    }
}

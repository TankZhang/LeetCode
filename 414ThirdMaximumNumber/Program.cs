using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/third-maximum-number/description/
namespace _414ThirdMaximumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ha = { 1,1,2  };
            Console.WriteLine(ThirdMax(ha));
            Console.ReadKey();
        }

        static int ThirdMax(int[] nums)
        {
            if (nums.Count() < 3)
                return nums.Max();
            int a = 0, b = -1, c = -1,cnt=0;
            for (int i = 1; i < nums.Count(); i++)
            {
                if(nums[i]>nums[a])
                { c = b;b = a;a = i; }
                else if(nums[i] == nums[a])
                { cnt++; }
                else
                {
                    if(b==-1)
                    { b = i; }
                    else if(nums[i]>nums[b])
                    { c = b;b = i; }
                    else if (nums[i]==nums[b])
                    { cnt++; }
                    else
                    {
                        if (c == -1)
                        { c = i; }
                        else if (nums[i] > nums[c])
                        { c = i; }
                        else if (nums[i] == nums[c])
                        { cnt++; }
                    }
                }
            }
            if (cnt > nums.Count() - 3)
                return nums[a];
            else
                return nums[c];
        }
    }
}

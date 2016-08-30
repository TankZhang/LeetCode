using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/longest-common-prefix/
namespace _14LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = {"laladsa","lalaweqdasd","lalaref" };
            Console.WriteLine(LongestCommonPrefix(strs));
            Console.ReadKey();
        }
        static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            int l = strs[0].Length;
            int n = strs.Length;
            string result = "";
            bool flag = false;
            for (int i=0;i<l;i++)
            {
                try
                {
                    foreach (string item in strs)
                    {
                        if (item[i] != strs[0][i])
                        { flag = true;
                        break; }
                    }
                    if (flag)
                        break;
                    result += strs[0][i];
                }
                catch
                { }
            }
            return result;
        }
    }
}

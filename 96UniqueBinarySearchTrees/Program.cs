using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/unique-binary-search-trees/
namespace _96UniqueBinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumTrees(5));
            Console.ReadKey();
        }
        static int NumTrees(int n)
        {
            if (n == 0)
                return 0;
            List<int> l = new List<int>() { 1 };
            for (int i = 2; i <=n; i++)
            {
                int num = l[i - 1-1] * 2;
                for (int j = 2; j < i; j++)
                {
                    num += l[j - 2] * l[i - j-1];
                }
                l.Add(num);
            }
            return l[n-1];
        }
    }
}

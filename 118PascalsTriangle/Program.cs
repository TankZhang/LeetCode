using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/pascals-triangle/
namespace _118PascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> l = Generate(5);
            foreach (IList<int> item in l)
            {
                foreach (int i in item)
                {
                    Console.Write("{0}  ", i);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> l = new List<IList<int>>();
            if (numRows == 0) return l;
            if (numRows == 1)
            {
                l.Add(new List<int>() { 1 });
                return l;
            }
            l.Add(new List<int>() { 1 });
            for (int i = 1; i < numRows; i++)
            {
                List<int> tmp = new List<int>();
                tmp.Add(1);
                for (int j = 1; j < i; j++)
                {
                    tmp.Add(l[i - 1][j - 1] + l[i - 1][j]);
                }
                tmp.Add(1);
                l.Add(tmp);
            }
            return l;
        }
    }
}

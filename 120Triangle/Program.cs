using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/triangle/
namespace _120Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>() { -1 };
            List<int> b = new List<int>() { 2, 3 };
            List<int> c = new List<int>() { 1, -1, -3 };
            List<int> d = new List<int>() { 4, 1, 8, 3 };
            List<int> e = new List<int>() { 4, 1, 8, 3, 12 };
            IList<IList<int>> z = new List<IList<int>>();
            z.Add(a);
            z.Add(b);
            z.Add(c);
            //z.Add(d);
            //z.Add(e);
            Console.WriteLine(MinimumTotal(z));
            Console.ReadKey();
        }
        static int MinimumTotal(IList<IList<int>> triangle)
        {
            int levelCount = triangle.Count;
            if (levelCount == 1)
                return triangle[0][0];
            if (levelCount == 2)
                return triangle[1][0] < triangle[1][1] ? triangle[1][0] + triangle[0][0] : triangle[1][1] + triangle[0][0];
            List <int> l = new List<int>();
            List<int> m = new List<int>();
            for (int i = 0; i < levelCount; i++)
            {
                l.Add(Int32.MaxValue);
                m.Add(Int32.MaxValue);
            }

            int temp1, temp2;
            l[0] = triangle[0][0];
            for (int i = 1; i < levelCount; i++)
            {
                if (i == 1)
                {
                    m[0] = l[0] + triangle[1][0];
                    m[1] = l[0] + triangle[1][1];
                }
                else if (i % 2 == 0)
                {
                    l[0] = m[0] + triangle[i][0];
                    for (int j = 1; j < i; j++)
                    {
                        l[j] = Math.Min(m[j - 1], m[j]) + triangle[i][j];
                    }
                    l[i] = m[i - 1] + triangle[i][i];
                }
                else
                {
                    m[0] = l[0] + triangle[i][0];
                    for (int j = 1; j < i; j++)
                    {
                        m[j] = Math.Min(l[j - 1], l[j]) + triangle[i][j];
                    }
                    m[i] = l[i - 1] + triangle[i][i];
                }
            }
            int min;
            if (levelCount % 2 == 0)
            {
                min = l[0];
                foreach (int item in l)
                {
                    min = min < item ? min : item;
                }
            }
            else
            {
                min = m[0];
                foreach (int item in m)
                {
                    min = min < item ? min : item;
                }

            }
            return min;
        }
    }
}

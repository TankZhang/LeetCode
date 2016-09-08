using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _119PascalsTriangleII
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in GetRow(4))
                Console.Write(item + " ");

            Console.ReadKey();
        }

        static IList<int> GetRow(int rowIndex)
        {
            IList<int> res = new List<int> { 1 };
            if (rowIndex == 0)
                return res;
            res.Add(1);
            if (rowIndex == 1)
                return res;
            int temp1 = 1,temp2;
            for (int i = 1; i < rowIndex; i++)
            {
                for (int j = 1; j < i + 1; j++)
                {
                    temp2 = res[j];
                    res[j] = res[j] + temp1;
                    temp1 = temp2;
                }
                res.Add(1);
            }
            return res;
        }
    }
}

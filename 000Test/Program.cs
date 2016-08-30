using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat= new int[,] { { 1,2 }, { 2,3 }, { 3,4 } };
            int[,] res = Go(true, mat);
            int r = mat.GetLength(0);
            int c = mat.GetLength(1);
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    Console.Write("{0}  ",res[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static int[,] Go(bool flag,int[,] mat)
        {
            int r = mat.GetLength(0);
            int c = mat.GetLength(1);
            int[,] temp = new int[c,r];
            for(int i=0;i<r;i++)
                for(int j=0;j<c;j++)
                {
                    if (flag)
                        temp[j, r - i - 1] = mat[i, j];
                    else
                        temp[c - j - 1, i] = mat[i, j];
                }
            return temp;
        }
    }
}

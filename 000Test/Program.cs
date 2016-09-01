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
            int a;
            Int32.TryParse(Console.ReadLine(), out a);
            SneakMatrix(a);
            Console.ReadKey();
        }
        
        //蛇形矩阵Go
            static void SneakMatrix(int n)
            {
                int[,] temp = new int[n, n];
                int pNow = 1;
                for (int i = 1; i < 2 * n; i++)
                {
                    switch (i % 4)
                    {
                        case 1:
                            for (int j = i / 4, k = i / 4; k < n - i / 4; k++)
                                temp[j, k] = pNow++;
                            break;
                        case 2:
                            for (int j = i / 4 + 1, k = n - 1 - i / 4; j < n - i / 4; j++)
                                temp[j, k] = pNow++;
                            break;
                        case 3:
                            for (int j = n - 1 - i / 4, k = n - 2 - i / 4; k > i / 4 - 1; k--)
                                temp[j, k] = pNow++;
                            break;
                        case 0:
                            for (int j = n -1- i / 4, k = i / 4-1; j > i / 4 - 1; j--)
                                temp[j, k] = pNow++;
                            break;
                    }
                }
                for (int i = 0; i < n * n; i++)
                {
                    System.Console.Write("{0} ", temp[i / n, i % n]);
                }
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

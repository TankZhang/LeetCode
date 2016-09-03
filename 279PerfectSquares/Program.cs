using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/perfect-squares/
namespace _279PerfectSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumSquares(12));
            Console.ReadKey();
        }
        static int NumSquares(int n)
        {
            int[] temp = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
                temp[i] = i;
            for (int i = 0; i < n+1; i++)
                for (int j = 1; j*j <= i; j++)
                    temp[i] = Math.Min(temp[i], temp[i - j * j] + 1);
            return temp[n];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/super-ugly-number/
namespace _313SuperUglyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NthSuperUglyNumber1(12, new int[] { 2, 7, 13, 19 }));
            Console.ReadKey();
        }
        #region n=1e6时候超时
        static int NthSuperUglyNumber(int n, int[] primes)
        {
            if (n == 1)
                return 1;
            int numNow = 2;
            int numTh = 1;
            while (numTh < n)
            {
                for (int i = numNow; ; i++)
                {
                    if (numTh == n)
                        return i - 1;
                    if (IsUgly(i, primes))
                        numTh++;
                }
            }
            return 0;
        }
        static bool IsUgly(int n, int[] primes)
        {
            for (int i = primes.Length - 1; i >= 0; i--)
                if (n / primes[i] != 0 && n % primes[i] == 0)
                {
                    if (n / primes[i] == 1)
                        return true;
                    else
                        return IsUgly(n / primes[i], primes);
                }
            return false;
        }
        #endregion

        static int NthSuperUglyNumber1(int n, int[] primes)
        {
            int[] dp = new int[n];
            int[] index = new int[primes.Length];
            for (int i = 0; i < n; i++)
                dp[i] = int.MaxValue;
            dp[0] = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < primes.Length; j++)
                    dp[i] = Math.Min(dp[i], dp[index[j]] * primes[j]);
                for (int j = 0; j < primes.Length; j++)
                    if (dp[i] % primes[j] == 0)
                        index[j]++;
            }
            return dp[n - 1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
namespace _121BestTimetoBuyandSellStock
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = {1,5,3,79,3 };
            Console.WriteLine("最大收益是:{0}",MaxProfit2(prices));
            Console.ReadKey();
        }

        //自己的太慢了
        static int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;
            int days = prices.Length;
            List<int> l = new List<int>();
            for (int i = 0; i < days; i++)
            {
                for (int j = i+1; j < days; j++)
                {
                    l.Add(prices[j] - prices[i]);
                }
            }
            l.Sort();
            if (l.Count == 0 || l[l.Count - 1] < 0)
                return 0;
            return l[l.Count - 1];
        }

        //简单的方法
        static int MaxProfit2(int[] prices)
        {
            if (prices.Length < 2)
                return 0;
            int days = prices.Length;
            int res = 0;
            int curMin = prices[0];
            for (int i = 0; i < days; i++)
            {
                curMin = Math.Min(curMin, prices[i]);
                res = Math.Max(res, prices[i] - curMin);
            }
            return res;
        }
    }
}

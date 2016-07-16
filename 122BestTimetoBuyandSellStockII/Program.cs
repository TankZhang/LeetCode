using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
namespace _122BestTimetoBuyandSellStockII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 1, 5, 3, 79, 3 };
            Console.WriteLine("最大收益是:{0}", MaxProfit(prices));
            Console.ReadKey();
        }


        //思想简单，但是这都没想出来。让我去撞墙吧！
        static int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;
            int res = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                res += prices[i] - prices[i - 1] > 0 ? prices[i] - prices[i - 1] : 0;
            }
            return res;
        }
    }
}

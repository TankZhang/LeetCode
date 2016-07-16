using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
namespace _123BestTimetoBuyandSellStockIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 1, 5, 3, 79, 3 };
            Console.WriteLine("最大收益是:{0}", MaxProfit(prices));
            Console.ReadKey();
        }

        //主要思想，前向遍历，后向遍历
        static int MaxProfit(int[] prices)
        {
            if (prices.Count() < 2)
                return 0;
            int n = prices.Length;
            int[] forward=new int[n];
            int[] backward = new int[n];
            int min = prices[0];
            int max = prices[n - 1];
            forward[0] = 0;
            backward[n-1] = 0;
            for (int i = 1; i < n; i++)
            {
                min = Math.Min(min, prices[i]);
                forward[i] = Math.Max(prices[i] - min, forward[i - 1]);
                max = Math.Max(max, prices[n - i]);
                backward[n - i - 1] = Math.Max(backward[n-i],max-prices[n-i]);
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                result = result > forward[i] + backward[i] ? result : forward[i] + backward[i];
            }

            return result;
        }
    }
}

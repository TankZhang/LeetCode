using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/combination-sum-ii/
namespace _40CombinationSumII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[7] { 10, 1, 2, 7, 6, 1, 5};
            int target = 8;
            IList<IList<int>> result = CombinationSum(num, target);
            
            Console.ReadKey();
        }

        static bool Contains(IList<IList<int>> all,IList<int> a)
        {
            foreach (var item in all)
            {
                if(item.Count==a.Count)
                {
                    int n = 0;
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (item[i] == a[i]) n++;
                    }
                    if (n == a.Count)
                        return true;
                }
            }
            return false;
        }

        //
        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> combination = new List<int>();
            Array.Sort(candidates);
            Go(candidates, result, combination, target, 0);
            IList<IList<int>> ultimateResult = new List<IList<int>>();
            foreach (var item in result)
            {
                if (Contains(ultimateResult, item)) continue;
                ultimateResult.Add(item);
            }
            return ultimateResult;
        }

        //主要思想：如果得到了目标值，将当前列表加入result。如果没有得到值，进入for循环，放入1个合适值，进入Go，如果合适退出，如果不合适进入for，for走完会退出Go，然后将最近的一个不合适的值去掉再在for中循环。
        private static void Go(int[] candidates, IList<IList<int>> result, List<int> combination, int target, int start)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }
            for (int i = start; i < candidates.Count() && candidates[i] <= target; i++)
            {
                combination.Add(candidates[i]);
                Go(candidates, result, combination, target - candidates[i], i+1);
                combination.Remove(combination.Last());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/combination-sum/
namespace _39CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[5] { 1,2,3,5,4};
            int target = 8;
            IList<IList<int>> result = CombinationSum(num, target);

            Console.ReadKey();
        }

        //
        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> combination = new List<int>();
            Array.Sort(candidates);
            Go(candidates, result, combination, target, 0);
            return result;
        }

        //
        private static void Go(int[] candidates, IList<IList<int>> result, List<int> combination, int target, int start)
        {
            if(target==0)
            {
                result.Add(new List<int>(combination));
                return;
            }
            for (int i = start; i < candidates.Count()&&candidates[i]<=target; i++)
            {
                combination.Add(candidates[i]);
                Go(candidates, result, combination, target - candidates[i], i);
                combination.Remove(combination.Last());
            }
        }
    }
}

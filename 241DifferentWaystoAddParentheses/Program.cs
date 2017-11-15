using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/different-ways-to-add-parentheses/description/
namespace _241DifferentWaystoAddParentheses
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (int item in DiffWaysToCompute("2*3-4*5"))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static IList<int> DiffWaysToCompute(string input)
        {
            IList<int> ret = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i]=='+'|| input[i] == '-' || input[i] == '*' )
                {
                    string a = input.Substring(0, i);
                    string b = input.Substring(i+1);
                    IList<int> retA = DiffWaysToCompute(a);
                    IList<int> retB = DiffWaysToCompute(b);
                    foreach (int item1 in retA)
                    {
                        foreach (int item2 in retB)
                        {
                            switch(input[i])
                            {
                                case '+':ret.Add(item1 + item2);break;
                                case '-': ret.Add(item1 - item2); break;
                                case '*': ret.Add(item1 * item2); break;
                            }
                        }
                    }
                }
            }
            if (ret.Count == 0)
                ret.Add(Convert.ToInt32(input));
            return ret;
        }
    }
}

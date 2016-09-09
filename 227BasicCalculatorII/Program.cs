using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/basic-calculator-ii/
namespace _227BasicCalculatorII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculate2("   30"));
            Console.ReadKey();
        }

        //模仿新方法
        static int Calculate2(string s)
        {
           s= s.Replace(" ", "");
            int res = 0;
            char op = '+';
            int pre = 0;
            int start = 0;
            int now = 0;
            while (start < s.Length)
            {
                if (char.IsDigit(s[start]))
                {
                    now = s[start] - '0';
                    start++;
                    while (start < s.Length && char.IsDigit(s[start]))
                    {
                        now = now * 10 + (s[start] - '0');
                        start++;
                    }
                    if (op == '+')
                    {
                        res += now;
                        pre = now;
                    }
                    if (op == '-')
                    {
                        res -= now;
                        pre = 0 - now;
                    }
                    if (op == '*')
                    {
                        res = res - pre + pre * now;
                        pre = pre * now;
                    }
                    if (op == '/')
                    {
                        res = res - pre + pre / now;
                        pre = pre / now;
                    }
                }
                else
                    op = s[start++];
            }
            return res;
        }

        //新方法
        static int Calculate1(string s)
        {
            if (s == null || s.Length == 0) { return 0; }

            s = s.Replace(" ", "");

            var result = 0;
            var prev = -1;

            var lastOp = '+';

            var start = 0;
            while (start < s.Length)
            {
                Console.WriteLine("Result: " + result + " Prev " + prev);
                Console.WriteLine("Visiting: " + s[start]);
                Console.WriteLine("LastOp " + lastOp);
                if (char.IsDigit(s[start]))
                {
                    var num = s[start] - '0';
                    start++;
                    while (start < s.Length && Char.IsDigit(s[start]))
                    {
                        num = num * 10 + s[start] - '0';
                        start++;
                    }

                    if (lastOp == '+')
                    {
                        result += num;
                        prev = num;
                    }
                    else if (lastOp == '-')
                    {
                        result -= num;
                        prev = -num;
                    }
                    else if (lastOp == '*')
                    {
                        result = result - prev + prev * num;
                        prev = prev * num;
                    }
                    else if (lastOp == '/')
                    {
                        result = result - prev + prev / num;
                        prev = prev / num;
                    }
                }
                else
                {
                    lastOp = s[start];
                    start++;
                }

            }

            return result;
        }

        static int Calculate(string s)
        {

            Stack<int> bigS = new Stack<int>();
            Stack<int> smallS = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    continue;
                string sT = "";
                if (char.IsDigit(s[i]))
                {
                    int ii = i;
                    while (ii < s.Length && char.IsDigit(s[ii]))
                        sT += s[ii++].ToString();
                    i += (sT.Length - 1);
                    if ((bigS.Count > 0) && (bigS.Peek() == 2 || bigS.Peek() == 3))
                    {
                        int b = int.Parse(sT);
                        int op = bigS.Pop();
                        int a = bigS.Pop();
                        bigS.Push(op == 2 ? a * b : a / b);
                    }
                    else
                    {
                        bigS.Push(int.Parse(sT));
                    }
                }
                else
                {
                    switch (s[i])
                    {
                        case '+':
                            bigS.Push(0);
                            break;
                        case '-':
                            bigS.Push(1); break;
                        case '*':
                            bigS.Push(2); break;
                        case '/':
                            bigS.Push(3); break;
                    }
                }
            }
            while (bigS.Count > 0)
                smallS.Push(bigS.Pop());

            int op_a = smallS.Pop();
            int op_b = 0;
            while (smallS.Count > 0)
            {
                int opp = smallS.Pop();
                op_b = smallS.Pop();
                op_a = opp == 0 ? op_a + op_b : op_a - op_b;
            }
            return op_a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/basic-calculator/
namespace _224BasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculate1("(1+(4+5+2)-3)+(6+8)"));
            Console.ReadKey();
        }

        //其他方法
        static int Calculate1(string s)
        {
            if (s == null || s.Length == 0) return 0;

            Stack<int> stack = new Stack<int>();
            int res = 0;
            int sign = 1;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (char.IsDigit(c))
                {
                    int cur = c - '0';
                    while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                    {
                        cur = 10 * cur + s[++i] - '0';
                    }
                    res += sign * cur;
                }
                else if (c == '-')
                {
                    sign = -1;
                }
                else if (c == '+')
                {
                    sign = 1;
                }
                else if (c == '(')
                {
                    stack.Push(res);
                    res = 0;
                    stack.Push(sign);
                    sign = 1;
                }
                else if (c == ')')
                {
                    res = stack.Pop() * res + stack.Pop();
                    sign = 1;
                }
            }
            return res;
        }

        static int Calculate(string s)
        {
            Stack<string> bigStack = new Stack<string>();
            for (int i = 0; i < s.Length; i++)
            {
                bigStack.Push(s[i].ToString());
                Check(bigStack);
            }

            Stack<string> smallStack = new Stack<string>();
            while (bigStack.Count > 0 && bigStack.Peek() != "(")
                smallStack.Push(bigStack.Pop());
            string s1 = "", s2 = "";
            string cal;
            while (smallStack.Count > 0 && smallStack.Peek() != "+" && smallStack.Peek() != "-")
                s1 += smallStack.Pop();
            cal = smallStack.Count > 0 ? smallStack.Pop() : "*";
            if (cal == "*") { bigStack.Push(s1); return int.Parse(s1); }
            while (smallStack.Count > 0)
            {
                while (smallStack.Count > 0 && smallStack.Peek() != "+" && smallStack.Peek() != "-")
                    s2 += smallStack.Pop();
                if (cal == "+")
                    s1 = (int.Parse(s1) + int.Parse(s2)).ToString();
                if (cal == "-")
                    s1 = (int.Parse(s1) - int.Parse(s2)).ToString();
                try { cal = smallStack.Pop(); }
                catch { }
                s2 = "";
            }
            return int.Parse(s1);
        }

        private static void Check(Stack<string> bigStack)
        {
            if (bigStack.Peek() == ")")
            {
                Stack<string> smallStack = new Stack<string>();
                bigStack.Pop();
                while (bigStack.Peek() != "(")
                    smallStack.Push(bigStack.Pop());
                bigStack.Pop();
                string s1 = "", s2 = "";
                string cal;
                while (smallStack.Count > 0 && smallStack.Peek() != "+" && smallStack.Peek() != "-")
                    s1 += smallStack.Pop();
                cal = smallStack.Count > 0 ? smallStack.Pop() : "*";
                if (cal == "*") { bigStack.Push(s1.ToString()); return; }
                while (smallStack.Count > 0)
                {
                    while (smallStack.Count > 0 && smallStack.Peek() != "+" && smallStack.Peek() != "-")
                        s2 += smallStack.Pop();
                    if (cal == "+")
                        s1 = (int.Parse(s1) + int.Parse(s2)).ToString();
                    if (cal == "-")
                        s1 = (int.Parse(s1) - int.Parse(s2)).ToString();
                    s2 = "";
                    try { cal = smallStack.Pop(); }
                    catch { }
                }
                bigStack.Push(s1);
            }

        }
    }
}

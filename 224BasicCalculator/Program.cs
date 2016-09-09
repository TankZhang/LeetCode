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

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            int result = 0, op = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i])) sb.Append(s[i]);
                if (i == s.Length - 1 || !char.IsDigit(s[i]))
                {
                    if (sb.Length != 0)
                        result += Convert.ToInt32(sb.ToString()) * op * stack.Peek();
                    if (s[i] == '+') op = 1;
                    else if (s[i] == '-') op = -1;
                    else if (s[i] == '(') { stack.Push(op * stack.Peek()); op = 1; }
                    else if (s[i] == ')') stack.Pop();
                    sb.Clear();
                }
            }
            return result;
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

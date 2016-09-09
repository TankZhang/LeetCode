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
            Console.WriteLine(Calculate("1 +1"));
            Console.ReadKey();
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
                    while (ii < s.Length&&char.IsDigit(s[ii]))
                        sT += s[ii++].ToString();
                    i+=(sT.Length-1);
                    if((bigS.Count>0)&&( bigS.Peek()==2||bigS.Peek()==3))
                    {
                        int b = int.Parse(sT);
                        int op = bigS.Pop();
                        int a = bigS.Pop();
                        bigS.Push(op == 2 ? a * b : a / b);
                    }
                    else { 
                    bigS.Push(int.Parse(sT));
                    }
                }
                else
                {
                    switch(s[i])
                    {
                        case '+':
                            bigS.Push(0);
                            break;
                        case '-':
                            bigS.Push(1);break;
                        case '*':
                            bigS.Push(2);break;
                        case '/':
                            bigS.Push(3);break;
                    }
                }
            }
            while(bigS.Count>0)
             smallS.Push(bigS.Pop());

            int op_a= smallS.Pop();
            int op_b = 0;
            while(smallS.Count>0)
            {
                int opp = smallS.Pop();
                op_b = smallS.Pop();
                op_a = opp == 0 ? op_a + op_b : op_a - op_b;
            }
            return op_a;
        }
    }
}

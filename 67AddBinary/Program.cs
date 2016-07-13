using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/add-binary/
namespace _67AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "10010";
            string b = "100";
            string c = AddBinary(a, b);
            Console.WriteLine(c);
            Console.ReadKey();
        }
       static string AddBinary(string a, string b)
        {
            int al = a.Length;
            int bl = b.Length;
            if(al>bl)
            {
                string temp = a;
                a = b;
                b = temp;
                al = al - bl;
                bl = bl + al;
                al = bl - al;
            }
            string c = "";
            bool flag=false;
            for (int i = 1; i <= bl; i++)
            {
                if (i <= al)
                {
                    if (a[al - i] == '1' && b[bl - i] == '1')
                    { c = (flag ? '1' : '0') + c; flag = true; }
                    else if (a[al - i] == '0' && b[bl - i] == '0')
                    { c = (flag ? '1' : '0') + c; flag = false; }
                    else
                    { c = (flag ? '0' : '1') + c; }
                }
                else
                {
                    if (b[bl - i] == '1')
                    { c = (flag ? '0' : '1') + c;  }
                    else
                    { c = (flag ? '1' : '0') + c; flag = false; }
                }
            }
            if (flag)
                c = '1' + c;
            return c;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/excel-sheet-column-title/
namespace _168ExcelSheetColumnTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToTitle(28));
            Console.ReadKey();
        }
        static string ConvertToTitle(int n)
        {
            string ss = "ZABCDEFGHIJKLMNOPQRSTUVWXY";
            string res = "";
            while(n>0)
            {
                res = ss[n % 26] + res;
                n = (n % 26 == 0) ? (n / 26 - 1) : (n / 26);
            }
            return res;
        }
    }
}

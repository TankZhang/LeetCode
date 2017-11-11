using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/zigzag-conversion/description/
namespace _006ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert("ABCDE", 4));
            Console.ReadKey();
        }
        static string Convert(string s, int numRows)
        {
            if (s == "")
                return s;
            if (numRows == 1)
                return s;

            int a, b;
            bool lFlag = false;
            int cnt = s.Count();
            a = cnt / (2 * numRows - 2);
            b = cnt % (2 * numRows - 2);
            lFlag = b > numRows ? true : false;
            string strRet = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < a * 2 + (lFlag ? 2 : 1); j++)
                {
                    if ((lFlag&&( j < a * 2+1))|| ((!lFlag) && (j < a * 2 )))
                    {
                        if (i != 0 && i != numRows - 1)
                            strRet += ((j % 2 == 0) ? s[j / 2 * (2 * numRows - 2) + i] : s[j / 2 * (2 * numRows - 2) + 2 * numRows - 2 - i]);
                        else
                            if (j % 2 == 0)
                                strRet += s[j / 2 * (2 * numRows - 2) + i];
                    }
                    else
                    {
                        if (lFlag && i == numRows - 1)
                        { }
                        else if (lFlag && (b - numRows > numRows - i - 2))
                            strRet += s[j / 2 * (2 * numRows - 2) + 2 * numRows - 2 - i];
                        else if (!lFlag && (b > i))
                            strRet += s[j / 2 * (2 * numRows - 2) + i];
                    }
                }
            }
            return strRet;
        }
    }
}

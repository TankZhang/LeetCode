using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/length-of-last-word/
namespace _58LengthofLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "hda dsi ds ";
            Console.WriteLine(LengthOfLastWord(s));
            Console.ReadKey();
        }

        //自己方法
        static int LengthOfLastWord(string s)
        {
            int length = s.Length;
            int i = 0;
            for (int j = length-1; j >=0; j--)
            {
                if (s[j] == ' ')
                {
                    if (i == 0)
                        continue;
                    else
                        break;
                }
                i++;
            }
            return i;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//https://leetcode.com/problems/regular-expression-matching/
namespace _10RegularExpressionMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "bc";
            string p = ".*bc";
            Console.WriteLine(Regex.IsMatch(s, p));
            Console.WriteLine(IsMatch(s, p));
            Console.ReadKey();
        }

        static bool IsMatch(string s, string p)
        {
            if (p == "")
                return s == "";
            if(p.Length==1||p[1]!='*')
            {
                if (p==s||(p.Length>0 &&s.Length>0&& p[0] == s[0]) || (p.StartsWith(".") && s.Length > 0))
                    return IsMatch(s.Substring(1), p.Substring(1));
                else
                    return false;
            }
            else
            {
                while(s.Length>0&&(s[0]==p[0]||p[0]=='.'))
                {
                    if (IsMatch(s, p.Substring(2)))
                        return true;
                    s = s.Substring(1);
                }
                return IsMatch(s, p.Substring(2));
            }
        }
    }
}

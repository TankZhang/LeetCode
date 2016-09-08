using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _342PowerofFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPowerOfFour(-2147483648));
            Console.ReadLine();
        }
        static bool IsPowerOfFour(int num)
        {
            if (num == 1)
                return true;
            string s = Convert.ToString(num, 2);
            if (s.Length % 2 == 1 && s[0] == '1' && Convert.ToInt32(s.Substring(1), 2) == 0)
                return true;
            else
                return false;
        }
    }
}

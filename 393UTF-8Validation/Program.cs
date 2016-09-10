using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/utf-8-validation/
namespace _393UTF_8Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 235, 140, 4 };
            Console.WriteLine(ValidUtf8(data));
            Console.ReadKey();
        }

        static bool ValidUtf8(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 248)
                    return false;
                else if (data[i] >= 240)
                {
                    if (!IsInSection(data[++i],128,192)|| !IsInSection(data[++i], 128, 192) || !IsInSection(data[++i], 128, 192))
                        return false;
                }
                else if (data[i] >= 224)
                {
                    if (!IsInSection(data[++i], 128, 192) || !IsInSection(data[++i], 128, 192))
                        return false;
                    Console.WriteLine(Convert.ToString(data[i], 2));
                }
                else if (data[i] >= 192)
                {
                    if (!IsInSection(data[++i], 128, 192))
                        return false;
                }
                else if (data[i] >= 128)
                    return false;
            }
            return true;
        }
        static bool IsInSection(int data,int low ,int high)
        { return data >= low && data < high; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/edit-distance/
namespace _72EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinDistance2("dinitrophenylhydrazine", "acetylphenylhydrazine"));
            Console.WriteLine(MinDistance2("", ""));

            Console.ReadKey();
        }

        //自己方法
        static int MinDistance(string word1, string word2)
        {
            int[,] nums = new int[word1.Length+1, word2.Length+1];
            for (int i = 0; i < word1.Length+1; i++)
            {
                for (int j = 0; j < word2.Length+1; j++)
                {
                    nums[i, j] = Int32.MaxValue;
                }
            }

            int distance= Go(word1, word2, nums);
            return distance;

        }
        //自己方法
        private static int Go(string word1, string word2, int[,] nums)
        {
            if (word1 == "" && word2 == "")
                return 0;
            else if (word1 == "")
                return word2.Length;
            else if (word2 == "")
                return word1.Length;
            if (word1[0] == word2[0])
                return Go(word1.Substring(1), word2.Substring(1), nums);
            else
            {
                int a, b, c;
                if(nums[word1.Length-1,word2.Length]!=Int32.MaxValue)
                {
                    a = nums[word1.Length - 1, word2.Length];
                }
                else
                {
                    a = Go(word1.Substring(1), word2, nums);
                    nums[word1.Length - 1, word2.Length] = a;
                }
                if (nums[word1.Length, word2.Length-1] != Int32.MaxValue)
                {
                    b = nums[word1.Length, word2.Length - 1];
                }
                else
                {
                    b = Go(word1, word2.Substring(1), nums);
                    nums[word1.Length, word2.Length - 1] = b;
                }
                if (nums[word1.Length - 1, word2.Length - 1] != Int32.MaxValue)
                {
                    c = nums[word1.Length - 1, word2.Length - 1];
                }
                else
                {
                    c = Go(word1.Substring(1), word2.Substring(1), nums);
                    nums[word1.Length - 1, word2.Length - 1] = c;
                }
                int d = Math.Min(Math.Min(a, b), c) + 1;
                return d;
            }
        }

        //简单办法dp
        static int MinDistance2(string word1, string word2)
        {
            int length1 = word1.Length;
            int length2 = word2.Length;
            if (length1 == 0)
                return length2;
            if (length2 == 0)
                return length1;
            int[,] nums = new int[length1 + 1, length2 + 1];
            for (int i = 0; i <=length1; i++)
            {
                nums[i, 0] = i;
            }
            for (int i = 0; i <=length2 ; i++)
            {
                nums[0, i] = i;
            }

            for (int i = 1; i <= length1; i++)
            {
                for (int j = 1; j <=length2; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        nums[i, j] = nums[i - 1, j - 1];
                    else
                    {
                        nums[i, j] = Math.Min(Math.Min(nums[i - 1, j], nums[i, j - 1]), nums[i - 1, j - 1]) + 1;
                    }
                }
            }

            return nums[length1, length2];
        }

    }
}

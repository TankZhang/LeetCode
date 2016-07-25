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
            Console.WriteLine(MinDistance("dinitrophenylhydrazine", "acetylphenylhydrazine"));
            Console.WriteLine(MinDistance("", ""));

            Console.ReadKey();
        }

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
    }
}

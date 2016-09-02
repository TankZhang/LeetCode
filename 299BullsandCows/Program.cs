using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/bulls-and-cows/
namespace _299BullsandCows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetHint("11", "11"));
            Console.ReadKey();
        }
        static string GetHint(string secret, string guess)
        {
            int nYes = 0, nNo = 0;
            List<char> lSecret = secret.ToList();
            List<char> lGuess = guess.ToList();
            int n = lGuess.Count;
            for (int i = 0; i < n; i++)
            {
                try
                {
                    if(lSecret[i]==lGuess[i])
                    {
                        lSecret.RemoveAt(i);
                        lGuess.RemoveAt(i);
                        nYes++;
                        i--;
                    }
                }
                catch { break; }
            }
            for(int i=0;i<n-nYes;i++)
            {
                try {
                    if(lSecret.Contains(lGuess[i]))
                    {
                        nNo++;
                        lSecret.Remove(lGuess[i]);
                    }
                }
                catch { break; }
            }
            return nYes + "A" + nNo + "B";
        }
        
    }
}

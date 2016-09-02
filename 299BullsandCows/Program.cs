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
            Console.WriteLine(GetHint2("114234123213433215465", "35325725727211"));
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

        //快速的解法
        static string GetHint2(string secret, string guess) { 
        int bulls = 0;
        int cows = 0;
        var dict = new Dictionary<char, int>();
        for(int i = 0; i<secret.Length; ++i){
            if (guess[i] == secret[i]){
                bulls++;
            }
            else{
                if (!dict.ContainsKey(secret[i])){
                    dict[secret[i]] = 0;
                }
                if (!dict.ContainsKey(guess[i])){
                    dict[guess[i]] = 0;
                }
                if (dict[secret[i]]++ < 0)
                    cows++;
                if (dict[guess[i]]-- > 0)
                    cows++;
            }
        }
        
        
        return bulls + "A" + cows + "B";
        }
    }
}

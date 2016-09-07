using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/candy/
namespace _135Candy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Candy(new int[] { 2, 2 }));
            Console.ReadKey();
        }

        static int Candy(int[] ratings)
        {
            int[] candys = new int[ratings.Length];
            for (int i = 0; i < candys.Length; i++)
                candys[i] = 1;
            for (int i = 1; i < candys.Length; i++)
                if (ratings[i] > ratings[i - 1])
                    candys[i] = candys[i - 1] + 1;
            for (int i = candys.Length-1; i >0; i--)
            if (ratings[i - 1] > ratings[i])
                    candys[i - 1] = candys[i - 1] > candys[i] ? candys[i - 1] : candys[i] + 1;
            return candys.Sum();
        }

        #region 希望五年后的我记得我有这段时光
        /*
        static int Candy(int[] ratings)
        {
            int bigest = 1,temp=1;
            int nPeople = ratings.Length;
            for (int i =1; i < nPeople; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    temp++;
                if (ratings[i] < ratings[i - 1])
                    temp = 1;
                bigest = bigest > temp ? bigest : temp;
            }

        }
        static int GetCandyNum(int[] ratings,int start,int candyNum)
        {
            int nPeople = ratings.Length;
            if (start >= nPeople)
                return candyNum;
            if (start == nPeople - 1)
                return ratings[start] > ratings[start - 1] ? candyNum + 2 : candyNum + 1;
            int steps,now ;
            bool isAsend;
            GetStep(ratings, start, out now, out steps, out isAsend);
            
            if (isAsend)
            {
                int oneCandy=1;
                for (int i = start; i < now; i++)
                    candyNum += (ratings[i+1]>ratings[i]?oneCandy++:oneCandy);
            }
            else
            {
                int oneCandy = 1;

            }

        }

        //得到步数，和是否为升序
        static void GetStep(int[] ratings,int start,out int now,out int steps,out bool isAsend)
        {
            int nPeople = ratings.Length;
            now = start;
            steps = 1;
            if (ratings[now + 1] > ratings[now])
            {
                isAsend = true;
                while (ratings[now + 1] >= ratings[now] && now + 1 < nPeople)
                {
                    steps += (ratings[now + 1] > ratings[now] ? 1 : 0);
                    now++;
                }
                return;
            }
            else
            {
                isAsend = false;
                while (ratings[now + 1] <= ratings[now] && now + 1 < nPeople)
                {
                    steps += (ratings[now + 1] < ratings[now] ? 1 : 0);
                    now++;
                }
                return;
            }
        }
        */
        #endregion
    }
}

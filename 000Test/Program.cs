using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Zhuanhuan();
            Console.ReadKey();
        }

        //二进制转换
        static void Zhuanhuan()
        {
            int n = int.Parse(Console.ReadLine());
            string s = "";
            int high = 90, low = -90, mid;
            while (s.Length < 6)
            {
                mid = (high + low) / 2;
                if (n >= mid)
                {
                    s += "1";
                    low = mid;
                }
                else
                {
                    s += "0";
                    high = mid;
                }
            }
            Console.WriteLine(s);
        }



        //输出多少对质数的和
        static void Zhishuhe(int n)
        {
            if (n == 1)
            {
                Console.WriteLine(0);
                return;
            }
            if (n == 2)
            {
                Console.WriteLine(1);
                return;
            }
            bool[] flags = new bool[n];
            flags[0] = false;
            flags[1] = true;
            flags[2] = true;
            for (int i = 3; i < n; i++)
            {
                flags[i] = true;
                for (int j = 2; j < i; j++)
                    if(i%j==0)
                    {
                        flags[i] = false;
                        break;
                    }
            }
            int count = 0;
            for (int i = 1; i < n/2+1; i++)
             if (flags[i] && flags[n - i])
                    count++;
            Console.WriteLine(count);
        }

        //实现最大面积
        static void ZuiDaMianji()
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int[] ints = new int[ss.Length];
            int[] lengths = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            { ints[i] = int.Parse(ss[i]);
                lengths[i] = 0; }
            for (int i=0;i<ss.Length;i++)
            {
                int high = ints[i];
                lengths[i] = high;
                for(int j=i+1;j<ss.Length;j++)
                {
                    if (ints[j] >= ints[i])
                        lengths[i] += high;
                    else
                        break;
                }
            }
            Array.Sort(lengths);

            Console.WriteLine(lengths[ss.Length-1]);
            Console.ReadKey();
        }

        //多叉树
        static void DuoChaShu()
        {
            string s = Console.ReadLine();
            List<List<int>> intL = new List<List<int>>();
            while(s!="")
            {
                string[] ss = s.Split(' ');
                List<int> iL = new List<int>();
                foreach (string item in ss)
                {
                    iL.Add(int.Parse(item));
                }
                intL.Add(iL);
                s = Console.ReadLine();
            }
            int[] nodeNum = new int[intL.Count];
            for (int i = 0; i < intL.Count; i++)
                nodeNum[i] = 0;
            List<List<int>> resList = new List<List<int>>();
            resList.Add(new List<int>() { intL[0][0] });
            int n = 1;
            while(IsThereN(n,intL,resList))
            {
                GetCeng(n, intL, resList);
                n++;
            }
            foreach (var item in resList)
            {
                foreach (var item1 in item)
                {
                    Console.Write("{0} ", item1);
                }
            }
        }

        //判断是否有下一层
        static bool IsThereN(int n, List<List<int>> intL, List<List<int>> resList)
        {
            foreach (var item in resList[n-1])
            {
                if (GetStart(intL, item)!=null)
                    return true;
            }
            return false;
        }


        static void GetCeng(int n, List<List<int>> intL, List<List<int>> resList)
        {
            List<int> cengList = new List<int>();
            for (int i = 0; i < resList[n-1].Count; i++)
            {
                List<int> temp = GetStart(intL, resList[n - 1][i]);
                if (temp == null)
                    continue;
                for (int j = 1; j < temp.Count; j++)
                    cengList.Add(temp[j]);
            }
            resList.Add(cengList);
        }

        static List<int> GetStart(List<List<int>> intL,int n)
        {
            foreach (var item in intL)
            {
                if (item[0] == n) 
                return item;
            }
            return null;
        }


        //小于某数
        static void Go()
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int[] intS = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
                intS[i] = int.Parse(ss[i]);
            int[] res = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                int count = 0;
                for (int j = i+1; j < ss.Length; j++)
                if (intS[j] < intS[i])
                        count++;
                res[i] = count;
            }
            for (int i = 0; i < ss.Length; i++)
            {
                Console.Write("{0} ", res[i]);
            }
        }



        //采购单
        static void CaiGouDan()
        {
            string s = Console.ReadLine();
            string[] sStart = s.Split(' ');
            int classNum = int.Parse(sStart[1]);
            s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int[] ns = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
                ns[i] = int.Parse(ss[i]);
            Array.Sort(ns);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < classNum; i++)
            {
                s = Console.ReadLine();
                if(dic.Keys.Contains(s))
                    dic[s]++;
                else
                    dic.Add(s, 1);
            }
            int small = 0, big = 0;
            int more = 0;
            int count = 0;
            int loop = 0;
            while (more != 1)
            {
                more = 1;
                foreach (var item in dic)
                    if (item.Value >= more)
                    {
                        more = item.Value;
                        s = item.Key;
                    }
                dic.Remove(s);
                small += (more * ns[loop]);
                big += (more * ns[ns.Length - loop - 1]);
                count += more;
                loop++;
            }
            for (int i = 0; i < dic.Count; i++)
            {
                small += ns[loop];
                big += ns[ns.Length - 1 - loop];
                loop++;
            }
            Console.WriteLine("{0} {1}", small, big);
        }
        //保卫方案,待完善
        static void Baowei()
        {
            string s = Console.ReadLine();
            int nNum = int.Parse(s);
            s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int[] hills = new int[nNum];
            for (int i = 0; i < nNum; i++)
                hills[i] = int.Parse(ss[i]);
            int res = nNum;
            for (int i = 0; i < nNum; i++)
                for (int j = i+2; j < i + nNum-2; j++)
                {
                    bool flag = true;
                    for (int k = i + 1; k < j - 1; k++)
                        if (hills[k % nNum] > hills[i] || hills[k % nNum] > hills[i])
                        { flag = false; break; }
                    if (flag)
                        res++;
                }
            Console.WriteLine(res);
        }


        //http://exercise.acmcoder.com/online/online_judge_ques?ques_id=1664&konwledgeId=134  股神
        static void GuShen()
        {
            string sTemp;
            List<int> valueList = new List<int>();
            valueList.Add(1);
            int nAdd = 1;
            bool isAdd = true;
            while ((sTemp = Console.ReadLine()) != null)
            {
                int dayNow = int.Parse(sTemp);
                try { Console.WriteLine(valueList[dayNow - 1]); }
                catch
                {
                    for (int k = valueList.Count; k <= dayNow; k++)
                    {
                        if (isAdd)
                        {
                            for (int kk = 0; kk < nAdd; kk++)
                                valueList.Add(valueList[valueList.Count - 1] + 1);
                            isAdd = false;
                            nAdd++;
                        }
                        else
                        {
                            valueList.Add(valueList[valueList.Count - 1] - 1);
                            isAdd = true;
                        }
                    }
                    Console.WriteLine(valueList[dayNow - 1]);
                }
            }
        }
        static void GuShen1()
        {
            string numStr;
            while ((numStr = Console.ReadLine()) != null)
            {
                ulong tempValue = 1;
                ulong lastsub = 2, numsetp = 3;
                for (ulong j = 1; j < ulong.Parse(numStr); j++)
                {
                    if (j == lastsub)
                    {
                        lastsub += numsetp;
                        tempValue--;
                        numsetp++;
                    }
                    else
                        tempValue++;

                }

                Console.WriteLine(tempValue);

            }

        }
        static void GuShen2()
        {
            string sTemp;
            while ((sTemp = Console.ReadLine()) != null)
            {
                long dayNow = long.Parse(sTemp);
                if (dayNow == 1)
                {
                    Console.WriteLine(1);
                    continue;
                }
                bool isAdd = true;
                long res = 1;
                long nAdd = 1;
                for (long i = 1; i < dayNow;)
                {
                    if (isAdd)
                    {
                        res += nAdd;
                        i += nAdd;
                        nAdd++;
                        isAdd = false;
                        if (i > dayNow)
                            res -= (i - dayNow);
                    }
                    else
                    {
                        i++;
                        res--;
                        isAdd = true;
                    }
                }
                Console.WriteLine(res);
            }
        }

        //蛇形矩阵Go
        static void SneakMatrix(int n)
        {
            int[,] temp = new int[n, n];
            int pNow = 1;
            for (int i = 1; i < 2 * n; i++)
            {
                switch (i % 4)
                {
                    case 1:
                        for (int j = i / 4, k = i / 4; k < n - i / 4; k++)
                            temp[j, k] = pNow++;
                        break;
                    case 2:
                        for (int j = i / 4 + 1, k = n - 1 - i / 4; j < n - i / 4; j++)
                            temp[j, k] = pNow++;
                        break;
                    case 3:
                        for (int j = n - 1 - i / 4, k = n - 2 - i / 4; k > i / 4 - 1; k--)
                            temp[j, k] = pNow++;
                        break;
                    case 0:
                        for (int j = n - 1 - i / 4, k = i / 4 - 1; j > i / 4 - 1; j--)
                            temp[j, k] = pNow++;
                        break;
                }
            }
            for (int i = 0; i < n * n; i++)
            {
                System.Console.Write("{0} ", temp[i / n, i % n]);
            }
        }

        static int[,] Go(bool flag, int[,] mat)
        {
            int r = mat.GetLength(0);
            int c = mat.GetLength(1);
            int[,] temp = new int[c, r];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                {
                    if (flag)
                        temp[j, r - i - 1] = mat[i, j];
                    else
                        temp[c - j - 1, i] = mat[i, j];
                }
            return temp;
        }
    }
}

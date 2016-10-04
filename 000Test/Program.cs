using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _000Test
{
    class ClassTest0921 : IComparable
    {
        public string a;
        public int b;
        public ClassTest0921(string astr, string bstr)
        {
            a = astr;
            b = int.Parse(bstr);
        }

        public int CompareTo(object obj)
        {
            ClassTest0921 tmp = (ClassTest0921)obj as ClassTest0921;
            if (string.Compare(a, tmp.a) > 0)
                return 1;
            else if (string.Compare(a, tmp.a) > 0)
                return -1;
            else
            {
                if (this.b > tmp.b)
                    return -1;
                else if (this.b < tmp.b)
                    return 1;
                else
                    return 0;
            }
        }
    }
    class TreeNode0921
    {
        public int value;
        public TreeNode0921 Left;
        public TreeNode0921 Right;
        public TreeNode0921(int i)
        {
            value = i;

        }
        public TreeNode0921() { }
    }
    class Node0921
    {
        public int Value;
        public Node0921 Next;
        public Node0921() { }
        public Node0921(int i) { Value = i; }
    }
    class MapPoint0922
    {
        public int x;
        public int y;
        public MapPoint0922(int a, int b)
        {
            x = a; y = b;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }

        //运行多少次
        static void Go0923()
        {
            int n = 32;
            int s = 0;
            for(int i=1;i<=n;i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 0; k <= (2*n); k++)
                    {
                        s++;
                    }
                }
            }
            Console.WriteLine(s);
        }

        //浪潮的求时间差
        static void Langchao0923time()
        {
            string str1 = Console.ReadLine();
            string[] strs1 = str1.Split(':');
            string str2 = Console.ReadLine();
            string[] strs2 = str2.Split(':');
            int[] is1 = new int[3];
            int[] is2 = new int[3];
            for (int i = 0; i < 3; i++)
            {
                is1[i] = int.Parse(strs1[i]);
                is2[i] = int.Parse(strs2[i]);
            }
            int sum= (is1[0] * 3600 + is1[1] * 60 + is1[2]) - (is2[0] * 3600 + is2[1] * 60 + is2[2]);
            Console.WriteLine(sum);
        }

        //浪潮题目
        static void LangChao0923()
        {
            String str;
            bool flag = true;
            while ((str = Console.ReadLine()) != null && str != "")
            {
                List<MapPoint0922> l = new List<MapPoint0922>();
                l.Add(new MapPoint0922(0, 0));
                int x = 0, y = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    switch (str[i])
                    {
                        case 'L':
                            x = l.Last().x - 1;
                            y = l.Last().y;
                            break;
                        case 'R':
                            x = l.Last().x + 1;
                            y = l.Last().y;
                            break;
                        case 'D':
                            x = l.Last().x;
                            y = l.Last().y - 1;
                            break;
                        case 'U':
                            x = l.Last().x;
                            y = l.Last().y + 1;
                            break;
                        default: break;
                    }
                    if (IsContain(l, x, y))
                    {
                        flag = false;
                        Console.WriteLine("BUG");
                        break;
                    }
                    l.Add(new MapPoint0922(x, y));
                }
                if (flag)
                    Console.WriteLine("OK");
                else
                    flag = true;
            }
        }
        static bool IsContain(List<MapPoint0922> l, int x, int y)
        {
            int count = 0;
            foreach (MapPoint0922 item in l)
            {
                int xc = Math.Abs(item.x - x);
                int yc = Math.Abs(item.y - y);
                if ((xc == 0 && yc < 2) || (xc < 2 && yc == 0))
                    count++;
            }
            if (count > 1)
                return true;
            else
                return false;
        }

        //只能打开一个程序的办法1,创建互斥体法：
        static void Only1_0922_1()
        {
            bool blnIsRunning;
            Mutex nutexApp = new Mutex(false, Assembly.GetExecutingAssembly().FullName, out blnIsRunning);
            Console.WriteLine(blnIsRunning);
            if (!blnIsRunning)
            {
                MessageBox.Show("程序已经运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
                Console.ReadKey();
        }
        //只能打开一个程序的办法2:保证同时只有一个客户端在运行
        static void Only1_0922_2()
        {
            Mutex mutexMyapplication = new Mutex(false, "OnePorcess.exe");
            if (!mutexMyapplication.WaitOne(100, false))
            {
                MessageBox.Show("程序" + Application.ProductName + "已经运行！", Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //链表反转测试
        static void ReveseLinkTest0921()
        {
            Node0921 start = new Node0921(1);
            start.Next = new Node0921(2);
            start.Next.Next = new Node0921(3);
            start.Next.Next.Next = new Node0921(4);
            start = ReverseLink0921(start);
            Console.WriteLine("Next is the reversed linklist!");
            while (start != null)
            {
                Console.WriteLine(start.Value);
                start = start.Next;
            }
        }

        static Node0921 ReverseLink0921(Node0921 start)
        {
            Node0921 now = start.Next;
            Node0921 before = start;
            while (now.Next != null)
            {
                Node0921 t = now.Next;
                now.Next = before;
                if (before == start)
                    before.Next = null;
                before = now;
                now = t;
            }
            now.Next = before;
            return now;
        }

        //BFS和DFS测试
        static void BFSandDFS0921()
        {
            TreeNode0921 t = new TreeNode0921(1);
            t.Left = new TreeNode0921(2);
            t.Right = new TreeNode0921(3);
            t.Left.Left = new TreeNode0921(4);
            Console.WriteLine("next is the BFS!");
            BFS0921(t);
            Console.WriteLine();
            Console.WriteLine("next is the DFS!");
            DFS0921(t);
        }

        static void BFS0921(TreeNode0921 tmp)
        {
            Queue<TreeNode0921> qTreeNode = new Queue<TreeNode0921>();
            TreeNode0921 t = tmp;
            qTreeNode.Enqueue(t);
            while (qTreeNode.Count != 0)
            {
                t = qTreeNode.Peek();
                Console.WriteLine(t.value);
                qTreeNode.Dequeue();
                if (t.Left != null)
                    qTreeNode.Enqueue(t.Left);
                if (t.Right != null)
                    qTreeNode.Enqueue(t.Right);
            }
        }

        static void DFS0921(TreeNode0921 tmp)
        {
            Stack<TreeNode0921> stackT = new Stack<TreeNode0921>();
            TreeNode0921 t = tmp;
            while (t != null || stackT.Count != 0)
            {
                while (t != null)
                {

                    Console.WriteLine(t.value);
                    stackT.Push(t);
                    t = t.Left;
                }
                if (stackT.Count != 0)
                {
                    t = stackT.Peek();
                    stackT.Pop();
                    t = t.Right;
                }
            }
        }

        //滴滴笔试
        static void TwoSort(string path)
        {

            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            List<ClassTest0921> l = new List<ClassTest0921>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] strs = line.Split(' ');
                l.Add(new ClassTest0921(strs[0], strs[1]));
            }
            l.Sort();
            foreach (ClassTest0921 item in l)
            {
                Console.WriteLine("{0} {1}", item.a, item.b);
            }
        }

        static void wanmei0919()
        {
            string str;
            List<int> lres = new List<int>();
            while ((str = Console.ReadLine()) != null && str != "")
            {
                string[] strs = str.Split(' ');
                int[] nums = new int[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    try
                    { nums[i] = int.Parse(strs[i]); }
                    catch
                    { nums[i] = -1; }
                }
                if (nums[0] <= 0)
                    Console.WriteLine("error");
                for (int i = 0; i < nums[0]; i++)
                    lres.Add(nums[i + 1]);
                try
                {
                    lres.Insert(nums[nums[0] + 1], nums[nums[0] + 2]);
                }
                catch
                {
                    Console.WriteLine("error");
                }
                try
                {
                    lres.RemoveAt(nums[nums.Length - 1]);
                }
                catch
                {
                    Console.WriteLine("error");
                }

                foreach (var item in lres)
                    Console.Write("{0} ", item);
            }
        }

        static bool IsPrimeNum(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        //迷宫问题
        static void Tiaochu()
        {
            string[] str = Console.ReadLine().Trim().Split(' ');
            int row = int.Parse(str[0]);
            int column = int.Parse(str[1]);
            int hp = int.Parse(str[2]);
            int[,] map = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                string[] inputs = Console.ReadLine().Trim().Split(' ');
                for (int j = 0; j < column; j++)
                    map[i, j] = int.Parse(inputs[j]);
            }
            Stack<int> sDirec = new Stack<int>();
            int nowR = 0;
            int nowC = 0;
            //bool isArrive = Tianchu(map, sDirec, nowR, nowC, hp,1);
            Console.WriteLine();
        }

        static int numOfZero(int n)
        {
            int num = 0, i;
            for (i = 5; i <= n; i *= 5)
            {
                num += n / i;
            }
            return num;
        }

        //伪代码
        static void charupaixu()
        {
            int[] A = { 29, 6, 28, 20, 2, 24 };
            for (int i = 1; i <= 3; i++)
            {
                int e = A[i];
                int j = i;
                while (j > 0)
                {
                    if (A[j - 1] > e)
                        A[j] = A[j - 1];
                    else
                        break;
                    j--;
                }
                A[j] = e;
            }
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
                    if (i % j == 0)
                    {
                        flags[i] = false;
                        break;
                    }
            }
            int count = 0;
            for (int i = 1; i < n / 2 + 1; i++)
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
            {
                ints[i] = int.Parse(ss[i]);
                lengths[i] = 0;
            }
            for (int i = 0; i < ss.Length; i++)
            {
                int high = ints[i];
                lengths[i] = high;
                for (int j = i + 1; j < ss.Length; j++)
                {
                    if (ints[j] >= ints[i])
                        lengths[i] += high;
                    else
                        break;
                }
            }
            Array.Sort(lengths);

            Console.WriteLine(lengths[ss.Length - 1]);
            Console.ReadKey();
        }

        //多叉树
        static void DuoChaShu()
        {
            string s = Console.ReadLine();
            List<List<int>> intL = new List<List<int>>();
            while (s != "")
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
            while (IsThereN(n, intL, resList))
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
            foreach (var item in resList[n - 1])
            {
                if (GetStart(intL, item) != null)
                    return true;
            }
            return false;
        }


        static void GetCeng(int n, List<List<int>> intL, List<List<int>> resList)
        {
            List<int> cengList = new List<int>();
            for (int i = 0; i < resList[n - 1].Count; i++)
            {
                List<int> temp = GetStart(intL, resList[n - 1][i]);
                if (temp == null)
                    continue;
                for (int j = 1; j < temp.Count; j++)
                    cengList.Add(temp[j]);
            }
            resList.Add(cengList);
        }

        static List<int> GetStart(List<List<int>> intL, int n)
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
                for (int j = i + 1; j < ss.Length; j++)
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
                if (dic.Keys.Contains(s))
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
                for (int j = i + 2; j < i + nNum - 2; j++)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/n-queens/
namespace _051N_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            IList<IList<string>> res = SolveNQueens(n);
            foreach (List<string> ls in res)
            {
                foreach (string s in ls)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> res = new List<IList<string>>();
            if(n==1)
            {
                res.Add(new List<string> { "Q" });
                return res;
            }
            int[,] chessboard = new int[n, n];
            Stack<int> pStack = new Stack<int>();
            int pNow = 0;
            pStack.Push(pNow);
            chessboard[0, 0] = -1;
            while (pNow<n*n)
            {
                if(pStack.Count==1&&pStack.Peek()>n-1)
                {
                    pNow = n * n;
                    continue;
                }
                for(int i=pNow;i<n*n;i++)
                {
                    if(CanPlant(chessboard,i/n,i%n))
                    {
                        pStack.Push(i);
                        pNow = i;
                        chessboard[pNow / n, pNow % n] = -1;
                        if(pStack.Count==n)
                        {
                            AddStr(pStack, res);
                            pNow = pStack.Pop();
                            chessboard[pNow / n, pNow % n] = 0;
                            pNow++;
                            while (pNow == n * n)
                            {
                                if (pStack.Count > 0) { 
                                pNow = pStack.Pop();
                                chessboard[pNow / n, pNow % n] = 0;
                                pNow++;
                                }
                                else
                                {
                                    pNow = n * n;
                                    break;
                                }
                            }
                            break;
                        }
                        break;
                    }
                    else if(i==n*n-1)
                    {
                        pNow = pStack.Pop();
                        chessboard[pNow / n, pNow % n] = 0;
                        pNow++;
                        while(pNow==n*n)
                        {
                            if (pStack.Count > 0)
                            {
                                pNow = pStack.Pop();
                                chessboard[pNow / n, pNow % n] = 0;
                                pNow++;
                            }
                            else
                            {
                                pNow = n * n;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return res;
        }

        static void AddStr(Stack<int> pStack, IList<IList<string>> res)
        {
            int n = pStack.Count;
            List<string> sTemp = new List<string>();
            for (int j = 0; j < n; j++)
            {
                string s = "";
                for (int k = 0; k < n; k++)
                {
                    if (k == pStack.ElementAt(n - 1 - j) % n)
                        s += "Q";
                    else
                        s += ".";
                }
                sTemp.Add(s);
            }
            res.Add(sTemp);
        }

        //矩阵相加
        static int[,] MatrixPlus(int[,] a, int[,] b)
        {
            int r = a.GetLength(0);
            int c = a.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    a[i, j] += b[i, j];
                }
            }
            return a;
        }
        //矩阵相减
        static int[,] MatrixMinus(int[,] a, int[,] b)
        {
            int r = a.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    a[i, j] -= b[i, j];
                }
            }
            return a;
        }
        //加入值
        static int[,] Add(int[,] chessboard, int a, int b)
        {
            int c = a < b ? a : b;
            int r = chessboard.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                chessboard[a, i]++;
                chessboard[i, b]++;
            }
            for (int i = a - c, j = b - c; i < r && j < r; i++, j++)
                chessboard[i, j]++;
            for (int i = a, j = b; i < r && j < r && i >= 0 && j >= 0; i--, j++)
                chessboard[i, j]++;
            for (int i = a, j = b; i < r && j < r && i >= 0 && j >= 0; i++, j--)
                chessboard[i, j]++;
            chessboard[a, b] -= 6;
            return chessboard;
        }
        //减去值
        static int[,] Remove(int[,] chessboard, int a, int b)
        {
            int c = a < b ? a : b;
            int r = chessboard.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                chessboard[a, i]--;
                chessboard[i, b]--;
            }
            for (int i = a - c, j = b - c; i < r && j < r; i++, j++)
                chessboard[i, j]--;
            for (int i = a, j = b; i < r && j < r && i >= 0 && j >= 0; i--, j++)
                chessboard[i, j]--;
            for (int i = a, j = b; i < r && j < r && i >= 0 && j >= 0; i++, j--)
                chessboard[i, j]--;
            chessboard[a, b] += 6;
            return chessboard;
        }
        //检查可不可以放
        static bool CanPlant(int[,] chessboard, int a, int b)
        {
            bool flag = true;
            int c = a < b ? a : b;
            int r = chessboard.GetLength(0);
            for (int i = 0; i < r; i++)
            {
                if (chessboard[a, i] < 0 || chessboard[i, b] < 0)
                    return false;
            }
            for (int i = a - c, j = b - c; i < r && j < r; i++, j++)
                if (chessboard[i, j] < 0)
                    return false;
            for (int i = a, j = b; i < r && j < r && i >= 0 && j >= 0; i--, j++)
                if (chessboard[i, j] < 0)
                    return false;
            for (int i = a, j = b; i < r && j < r && i >= 0 && j >= 0; i++, j--)
                if (chessboard[i, j] < 0)
                    return false;
            return flag;
        }
    }
}

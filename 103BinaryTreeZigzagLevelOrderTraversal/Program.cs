using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
namespace _103BinaryTreeZigzagLevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(0);
            TreeNode head = root;
            head.left = new TreeNode(1);
            head.right = new TreeNode(2);
            head = head.right;
            head.left = new TreeNode(3);
            head.right = new TreeNode(4);
            List<List<int>> result = ZigzagLevelOrder2(root);
            ReadList(result);
            Console.ReadKey();
        }

        //读取List，显示用
        static void ReadList(List<List<int>> l)
        {
            foreach (List<int> item in l)
            {
                foreach (int i in item)
                {
                    Console.Write("{0}  ", i);
                }
                Console.WriteLine();
            }
        }

        //参考的方法
        static List<List<int>> ZigzagLevelOrder2(TreeNode root)
        {
            List<List<int>> l = new List<List<int>>();
            if (root == null) return l;
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2 = new Stack<TreeNode>();
            s1.Push(root);
            int n1 = s1.Count;
            int n2 = s2.Count;
            while(n1!=0||n2!=0)
            {
                n1 = s1.Count;
                n2 = s2.Count;
                List<int> tempL = new List<int>();
                for (int i = 0; i < n1; i++)
                {
                    root = s1.Pop();
                    tempL.Add(root.val);
                    if (root.left != null)
                        s2.Push(root.left);
                    if (root.right != null)
                        s2.Push(root.right);
                }
                for (int i = 0; i < n2; i++)
                {
                    root = s2.Pop();
                    tempL.Add(root.val);
                    if (root.right != null)
                        s1.Push(root.right);
                    if (root.left != null)
                        s1.Push(root.left);
                }
                l.Add(tempL);
            }
            l.RemoveAt(l.Count - 1);
            return l;
        }

            //自己的办法
            static List<List<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<List<int>> l = new List<List<int>>();
            if (root == null) return l;
            GetResult(0, root, l);
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < l.Count; i++)
            {
                result.Add(new List<int>());
                if (i % 2 == 0)
                {
                    for (int j = 0; j < l[i].Count; j++)
                    {
                        result[i].Add(l[i][j]);
                    }
                }
                else
                {
                    for (int j = 0; j < l[i].Count; j++)
                    {
                        result[i].Add(l[i][l[i].Count - j - 1]);
                    }

                }
            }
            return result;
        }

        //得到正序的数据List
        static void GetResult(int level, TreeNode root, List<List<int>> result)
        {
            if (root == null)
                return;
            if (result.Count <= level)
                result.Add(new List<int>());
            result[level].Add(root.val);
            GetResult(level + 1, root.left, result);
            GetResult(level + 1, root.right, result);
        }
    }


    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}

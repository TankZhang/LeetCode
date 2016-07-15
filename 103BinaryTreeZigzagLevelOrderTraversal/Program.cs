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
            List<List<int>> result = ZigzagLevelOrder(root);
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

        static List<List<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<List<int>> l = new List<List<int>>();
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

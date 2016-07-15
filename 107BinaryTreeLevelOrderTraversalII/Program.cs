using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
namespace _107BinaryTreeLevelOrderTraversalII
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
            List<List<int>> result = LevelOrderBottom(root);
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

        //得到逆序的数据List
        static List<List<int>> LevelOrderBottom(TreeNode root)
        {
            List<List<int>> temp = new List<List<int>>();
            GetResult(0, root, temp);
            List<List<int>> result = new List<List<int>>();
            for (int i = temp.Count-1; i >=0; i--)
            {
                result.Add(temp[i]);
            }
            return result;
        }

        //得到正序的数据List
        static void GetResult(int level,TreeNode root,List<List<int>> result)
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

    //节点的定义
     public class TreeNode
    {
     public int val;
     public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
}

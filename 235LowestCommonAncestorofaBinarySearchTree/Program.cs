using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
//此题目为二叉搜索树
namespace _235LowestCommonAncestorofaBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            TreeNode root = new TreeNode(n);
            Creat(root, n - 1);
            TreeNode parent = LowestCommonAncestor2(root, root.left.left, root.left.left.right);
            Console.WriteLine(parent.val);
            Console.ReadKey();
        }

        //创建二叉树
        private static void Creat(TreeNode root, int n)
        {
            root.left = new TreeNode(5);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(7);
            root.left.left.left = new TreeNode(1);
            root.left.left.right = new TreeNode(4);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(23);
        }

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p == null) return q;
            if (q == null) return p;
            if (root == null || root == p || root == q)
                return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
                return root;
            else if (left == null)
                return right;
            else
                return left;
        }

        static TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor2(root.left, p, q);
            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor2(root.right, p, q);
            return root;
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; left = null; right = null; }
    }
}

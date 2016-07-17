using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
namespace _236LowestCommonAncestorofaBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            TreeNode root = new TreeNode(n);
            Creat(root,n-1);
            TreeNode parent = LowestCommonAncestor(root, root.left.left, root.left.right.left);
            Console.WriteLine(parent.val);
            Console.ReadKey();
        }

        private static void Creat(TreeNode root, int n)
        {
            if (n < 0) return;
                root.left = new TreeNode(n);
                root.right = new TreeNode(n+1);
            Creat(root.left, n - 1);
            Creat(root.right, n - 1);
        }

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null) return null;
            Dictionary<TreeNode, TreeNode> dic = new Dictionary<TreeNode, TreeNode>();
            dic.Add(root, null);
            GetParents(root, dic);
            List<TreeNode> l1 = GetList(p, dic);
            List<TreeNode> l2 = GetList(q, dic);
            foreach (TreeNode pq in l1)
            {
                if (l2.Contains(pq))
                    return pq;
            }
            return null;
        }

       static void GetParents(TreeNode root, Dictionary<TreeNode, TreeNode> dic)
        {
            if (root == null)
                return;
            if (root.left != null)
            {
                dic.Add(root.left, root);
                GetParents(root.left, dic);
            }
            if (root.right != null)
            {
                dic.Add(root.right, root);
                GetParents(root.right, dic);
            }
        }

       static List<TreeNode> GetList(TreeNode t, Dictionary<TreeNode, TreeNode> dic)
        {
            List<TreeNode> l = new List<TreeNode>();
            if (t == null) return l;
            l.Add(t);
            TreeNode start = t;
            while (dic[start] != null)
            {
                start = dic[start];
                l.Add(start);
            }
            return l;
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

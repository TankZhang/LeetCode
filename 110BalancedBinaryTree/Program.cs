using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/balanced-binary-tree/description/
namespace _110BalancedBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region my solution
        static bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            if (root.left != null && root.right != null)
                return Math.Abs(Depth(root.left) - Depth(root.right)) > 1 ? false : IsBalanced(root.left) && IsBalanced(root.right);
            else if (root.left != null)
                return Depth(root.left) > 0 ? false : IsBalanced(root.left);
            else if (root.right != null)
                return Depth(root.right) > 0 ? false : IsBalanced(root.right);
            else
                return true;
        }

        static int Depth(TreeNode root)
        {
            if (root.left != null && root.right != null)
                return 1 + Math.Max(Depth(root.left), Depth(root.right));
            else if (root.left != null)
                return 1 + Depth(root.left);
            else if (root.right != null)
                return 1 + Depth(root.right);
            else
                return 0;
        }
        #endregion

        #region ref
        //https://discuss.leetcode.com/topic/3746/accepted-o-n-solution
        static bool IsBalanced1(TreeNode root)
        {
            if (GetDepth(root, 0) == int.MaxValue) return false;
            else return true;
        }
        static int GetDepth(TreeNode root, int depth)
        {
            if (root == null) return depth;

            int depthLeft = GetDepth(root.left, depth + 1);
            int depthRight = GetDepth(root.right, depth + 1);

            if (Math.Abs(depthLeft - depthRight) > 1)
                return int.MaxValue;

            int maxDepth = Math.Max(depthLeft, depthRight);

            return maxDepth;
        }
    }
    #endregion
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}

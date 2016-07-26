using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/same-tree/
namespace _100SameTree
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        //简单但是速度慢
        static bool IsSameTree2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            return (p.val == q.val) && IsSameTree2(p.left, q.left) && IsSameTree2(p.right, q.right);
        }

        //复杂但是速度快
        static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if ((p != null && q == null) || (p == null && q != null))
                return false;
            if (p == null && q == null)
                return true;
            if(p.val == q.val&&p.left==null && p.right==null&&q.left==null&&q.right==null)
            {
                return true;
            }
            if(p.val == q.val&&p.left != null && p.right == null && q.left != null && q.right == null )
            {
                return IsSameTree(p.left, q.left);
            }
            if (p.val == q.val&&p.left == null && p.right != null && q.left == null && q.right != null )
            {
                return IsSameTree(p.right, q.right);
            }
            if (p.val == q.val&&p.left != null && p.right != null && q.left != null && q.right != null )
            {
                return IsSameTree(p.right, q.right)&& IsSameTree(p.left, q.left);
            }
            return false;
        }
    }

     public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
}

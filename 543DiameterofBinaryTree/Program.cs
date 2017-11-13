using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/diameter-of-binary-tree/description/
namespace _543DiameterofBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "dasd";

        }

        int maxLen = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;
            DiameterOfBinaryTree(root.left);
            DiameterOfBinaryTree(root.right);
            maxLen = Math.Max(FindMax(root.left) + FindMax(root.right), maxLen);
            return maxLen;
        }

        static int FindMax(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(FindMax(root.left), FindMax(root.right));
        }
    }

    //This problem makes me feel bad.What a hard problem.Maybe this is easy to the students that major in program...
    // I didn't code for half year, it really makes me fell uncomfortable.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102BinaryTreeLevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Go(result,root,0);

            return result;
        }

        private static void Go(IList<IList<int>> result, TreeNode root, int level)
        {
            if (root == null)
                return;
            if (result.Count > level)
                result[level].Add(root.val);
            else
            {
             result.Add(new List<int>() {root.val});
            }
            Go(result, root.left, level + 1);
            Go(result, root.right, level + 1);
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

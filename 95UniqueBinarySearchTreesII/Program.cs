using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/unique-binary-search-trees-ii/
namespace _95UniqueBinarySearchTreesII
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<TreeNode> l = GenerateTrees(5);
            Console.ReadKey();
        }

        private static IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0) return new List<TreeNode>();
            IList<IList<TreeNode>> allTrees = new List<IList<TreeNode>>();
            TreeNode treenode = new TreeNode(1);
            allTrees.Add(new List<TreeNode>() { treenode });
            if (n == 1) return allTrees[0];
            for (int i = 2; i <= n; i++)
            {
                IList<TreeNode> ltmp = new List<TreeNode>();
                for (int j = 1; j <= i; j++)
                {
                    // if top tree is j.so need to foreach the (j-1)th treeList and (i-j)th treeList ,
                    //this will generate a*b rootTreeNode. a stands for the num of (j-1)th treeList's treenodes and b stands for the num of (i-j)th treeList's treenodes.
                    if (j > 1&&j<i)
                    {
                        foreach (TreeNode tt1 in allTrees[j - 2])
                        {
                            foreach (TreeNode tt2 in allTrees[i-j-1])
                            {
                                TreeNode t = new TreeNode(j);
                                t.left = Copy(tt1, 0);
                                t.right = Copy(tt2, j);
                                ltmp.Add(t);
                            }
                        }
                    }
                    // if top tree is 1,so just to foreach the (i-1)th treeList,because all the nodes are in the right.
                    if(j==1)
                    {
                        foreach (TreeNode tt1 in allTrees[i-2])
                        {
                            TreeNode t1 = new TreeNode(j);
                            t1.right = Copy(tt1, 1);
                            ltmp.Add(t1);
                        }
                    }
                    // if top tree is i,so just to foreach the (i-1)th treeList,because all the nodes are in the left.
                    if (j==i)
                    {
                        foreach (TreeNode tt2 in allTrees[i-2])
                        {
                            TreeNode t1 = new TreeNode(j);
                            t1.left = Copy(tt2, 0);
                            ltmp.Add(t1);
                        }
                    }
                }
                allTrees.Add(ltmp);
            }
            return allTrees[n - 1];
        }

        //deep copy
        private static TreeNode Copy(TreeNode sour, int n)
        {
            if (sour == null) return null;
            TreeNode des = new TreeNode(sour.val + n);
            des.right = Copy(sour.right, n);
            des.left = Copy(sour.left, n);
            return des;
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

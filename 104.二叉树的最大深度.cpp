/*
 * @lc app=leetcode.cn id=104 lang=cpp
 *
 * [104] 二叉树的最大深度
 *
 * https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/description/
 *
 * algorithms
 * Easy (70.45%)
 * Likes:    345
 * Dislikes: 0
 * Total Accepted:    72.7K
 * Total Submissions: 102.7K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，找出其最大深度。
 * 
 * 二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
 * 
 * 说明: 叶子节点是指没有子节点的节点。
 * 
 * 示例：
 * 给定二叉树 [3,9,20,null,null,15,7]，
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 返回它的最大深度 3 。
 * 
 */
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
#include<utility>
#include<stack>
using namespace std;
class Solution {
public:
    int maxDepth(TreeNode* root) {   
        using Pair=pair<TreeNode*,int>;
        stack<Pair> st;
        int maxDepth=0;
        if(!root) 
            return 0;
        st.emplace(root,1);
        while(!st.empty()){
            auto cur=st.top();st.pop();
            int curDepth=cur.second;
            auto curRoot=cur.first;
            maxDepth=max(curDepth,maxDepth);
            if(curRoot->left) st.emplace(curRoot->left,curDepth+1);
            if(curRoot->right) st.emplace(curRoot->right,curDepth+1);
        }
        return maxDepth;
    }
};


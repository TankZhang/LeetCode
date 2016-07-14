// 117PopulatingNextRightPointersinEachNodeII.cpp : 定义控制台应用程序的入口点。
//https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/

#include "stdafx.h"
#include "stdlib.h"


struct TreeLinkNode {
	int val;
	struct TreeLinkNode *left, *right, *next;
};

//根据父节点寻找起始节点
struct TreeLinkNode*   FindStart(struct TreeLinkNode *par)
{
	while (par != NULL)
	{
		if (par->left != NULL)
			return par->left;
		if (par->right != NULL)
			return par->right;
		par = par->next;
	}
	return NULL;
}

//根据父节点和当前结点寻找下一节点
struct TreeLinkNode*   FindNext(struct TreeLinkNode **par, struct TreeLinkNode *sta)
{
	while ((*par) != NULL)
	{
		if (sta == (*par)->left)
		{
			if ((*par)->right != NULL)
				return (*par)->right;
			else
			{
				(*par) = (*par)->next; continue;
			}
		}
		else if (sta == (*par)->right)
		{
			(*par) = (*par)->next; continue;
		}
		else
		{
			if ((*par)->left != NULL || (*par)->right != NULL)
				return (*par)->left != NULL ? (*par)->left : (*par)->right;
			else
			{
				(*par) = (*par)->next; continue;
			}
		}
	}
	return NULL;
}

//连接树的每层
void connect(struct TreeLinkNode *root) {
	if (root == NULL)return;
	struct TreeLinkNode *parA = root;
	struct TreeLinkNode *parB = root;
	struct TreeLinkNode *staA = root;
	struct TreeLinkNode *staB = root;
	struct TreeLinkNode *next = root;
	while (parA!= NULL)
	{
		staA = FindStart(parA);
		parA = staA;
		staB = staA;
		next = FindNext(&parB, staB);
		while (next != NULL)
		{
			staB->next = next;
			staB = next;
			next = FindNext(&parB, staB);
		}
		parB = parA;
	}
}

//网上的答案
void connect1(struct TreeLinkNode *root) {
	struct TreeLinkNode *pos, *tmp, *level, *tag;
	if (root == NULL)
		return;
	level = root;
	while (true)
	{
		pos = level;
		tag = level;
		tmp = NULL;
		while (pos)
		{
			if (pos->left)
			{
				if (!tmp)
					tmp = level = pos->left;
				else
					tmp = tmp->next = pos->left;
			}
			if (pos->right)
			{
				if (!tmp)
					tmp = level = pos->right;
				else
					tmp = tmp->next = pos->right;
			}
			pos = pos->next;
		}
		if (tag == level) //No next level
			break;
	}
}

//构造树结构
void Creat(struct TreeLinkNode *root, int n)
{
	if (n < 0)return;
	struct TreeLinkNode *left = (TreeLinkNode*)malloc(sizeof(TreeLinkNode));
	left->val = n--;
	left->next = NULL;
	left->left = NULL;
	left->right = NULL;
	root->left = left;
	struct TreeLinkNode *right = (TreeLinkNode*)malloc(sizeof(TreeLinkNode));
	right->val = n--;
	right->next = NULL;
	right->left = NULL;
	right->right = NULL;
	root->right = right;
	Creat(left, n);
	Creat(right, n);
}


int main()
{
	struct TreeLinkNode *root = (TreeLinkNode*)malloc(sizeof(TreeLinkNode));
	int n = 4;
	root->val = n;
	root->next = NULL;
	root->left = NULL;
	root->right = NULL;
	struct TreeLinkNode *temp = root;
	Creat(temp, n - 1);
	root->left->left = NULL;
	root->left->right = NULL;
	temp = root;
	connect1(temp);
	getchar();
	return 0;

}


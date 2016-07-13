// 116PopulatingNextRightPointersinEachNode.cpp : 定义控制台应用程序的入口点。
//https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

#include "stdafx.h"
#include "stdlib.h"


 struct TreeLinkNode {
  int val;
  struct TreeLinkNode *left, *right, *next;
 };


void connect(struct TreeLinkNode *root) {
	if (NULL == root)
		return;
	struct TreeLinkNode *curLevel;
	while (root->left != NULL)
	{
		curLevel = root;
		while (curLevel != NULL)
		{
			curLevel->left->next = curLevel->right;
			if (curLevel->next != NULL) {
				curLevel->right->next = curLevel->next->left;
			}
			curLevel = curLevel->next;
		}
		root = root->left;
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
	int n = 10;
	root->val = n;
	root->next = NULL;
	root->left = NULL;
	root->right = NULL;
	struct TreeLinkNode *temp = root;
	Creat(temp, n-1);
	temp = root;
	connect(temp);
	getchar();
	return 0;

}


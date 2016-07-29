//https://leetcode.com/problems/reverse-linked-list-ii/

#include<stdio.h>
#include<stdbool.h>

struct ListNode {
	int val;
	struct ListNode *next;
}ListNode;

typedef struct ListNode* pListNode;

struct ListNode* reverseBetween(struct ListNode* head, int m, int n) {
	if (head->next == NULL)return head;
	if (m == n)return head;
	if (head->next->next == NULL&&m != n)
	{
		pListNode temp1 = head->next;
		head->next->next = head;
		head->next = NULL;
		return temp1;
	}
	int nbig = m > n ? m : n;
	int nsmall = m + n - nbig;
	pListNode presmall;
	pListNode aftbig;
	pListNode cur = head;
	pListNode bign;
	pListNode smalln;
	pListNode pre=NULL;
	for (int i = 1; i <=nbig ; i++)
	{
		if (i == nsmall)
		{
			smalln = cur;
			presmall = pre;
		}
		if (i == nbig)
		{
			bign = cur;
			aftbig = bign->next;
		}
		pre = cur;
		cur = cur->next;
	}

	cur = smalln;

	pListNode thead;
	pre = presmall;
	while (cur != aftbig)
	{
		thead = cur->next;
		cur->next = pre;
		pre = cur;
		cur = thead;
	}
	if (presmall == NULL)
		head = bign;
	else
		presmall->next = bign;
	smalln->next = aftbig;
	return head;
}

//Éú³ÉÁ´±í
pListNode Gen(int nums[], int n)
{
	pListNode head = (pListNode)malloc(sizeof(ListNode));
	pListNode cur = head;
	for (int i = 0; i < n - 1; i++)
	{
		cur->val = nums[i];
		cur->next = (pListNode)malloc(sizeof(ListNode));
		cur = cur->next;
	}
	cur->val = nums[n - 1];
	cur->next = NULL;
	return head;
}

void main()
{
	int nums[] = { 1,2,3,4 };
	pListNode root = Gen(nums, 4);

	root = reverseBetween(root, 1, 4);

	while (root != NULL)
	{
		printf("%d  ", root->val);
		root = root->next;
	}
	getchar();
}
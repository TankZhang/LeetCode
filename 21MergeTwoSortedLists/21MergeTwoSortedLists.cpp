// 21MergeTwoSortedLists.cpp : 定义控制台应用程序的入口点。
//https://leetcode.com/problems/merge-two-sorted-lists/

#include "stdafx.h"
#include "stdlib.h"

struct ListNode {
	int val;
	struct ListNode *next;
};

struct ListNode* mergeTwoLists(struct ListNode* l1, struct ListNode* l2) {
	if ((l1 == NULL) || (NULL == l2))
		return (NULL == l1) ? l2 : l1;

	struct ListNode* head;
	struct ListNode* temp;
	if (l1->val<l2->val)
	{
		head = l1;
		l1 = l1->next;
	}
	else
	{
		head = l2;
		l2 = l2->next;
	}
	temp = head;
	while ((NULL != l1) && (NULL != l2))
	{
		if (l1->val<l2->val)
		{
			temp->next = l1;
			temp = l1;
			l1 = l1->next;
		}
		else
		{
			temp->next = l2;
			temp = l2;
			l2 = l2->next;
		}
	}
	if (l1)
		temp->next = l1;
	if (l2)
		temp->next = l2;
	return head;
}

int main()
{
	ListNode* l1 = (ListNode*)malloc(sizeof(ListNode));
	l1->val = -1;
	l1->next = NULL;
	ListNode* l11 = l1;
	for (int i = 1; i < 40; i*=2)
	{
		ListNode* t1= (ListNode*)malloc(sizeof(ListNode));
		t1->val = i;
		t1->next = NULL;
		l11->next = t1;
		l11 = t1;
	}
	ListNode* l2 = (ListNode*)malloc(sizeof(ListNode));
	l2->val = -1;
	l2->next = NULL;
	ListNode* l22 = l2;
	for (int i = 0; i < 5; i ++)
	{
		ListNode* t2 = (ListNode*)malloc(sizeof(ListNode));
		t2->val = i;
		t2->next = NULL;
		l22->next = t2;
		l22 = t2;
	}

	ListNode* result = mergeTwoLists(l1, l2);

	while (NULL!=result)
	{
		printf("%d\n", result->val);
		result = result->next;
	}
	getchar();
    return 0;
}



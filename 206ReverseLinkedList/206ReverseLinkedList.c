
//https://leetcode.com/problems/reverse-linked-list/

#include<stdio.h>
#include<malloc.h>

 struct ListNode {
	int val;
	struct ListNode *next;
}ListNode;

typedef struct ListNode* pListNode;


 struct ListNode* reverseList(struct ListNode* head) {
	 if (head == NULL||head->next==NULL)
		 return head;
	 pListNode cur = NULL;
	 pListNode pre=head;
	 head = head->next;
	 pre->next = cur;
	 while (head->next!= NULL)
	 {
		 cur = head;
		 head = head->next;
		 cur->next = pre;
		 pre = cur;
	 }
	 head->next = pre;
	 return head;
 }


 struct ListNode* reverseList2(struct ListNode* head) {
	 if (head == NULL || head->next == NULL)
		 return head;
	 pListNode cur = head;
	 pListNode pre = NULL;
	 while (cur!=NULL)
	 {
		 head = cur->next;
		 cur->next = pre;
		 pre = cur;
		 cur = head;
	 }
	 return pre;
 }


 struct ListNode* reverseList3(struct ListNode* head) {
	 if (head == NULL || head->next == NULL)
		 return head;
	 pListNode p = reverseList3(head->next);
	 head->next->next = head;
	 head->next = NULL;
	 return p;
 }


 int main()
 {
	 pListNode root = (pListNode)malloc(sizeof(ListNode));
	 root->val = 4;
	 root->next= (pListNode)malloc(sizeof(ListNode));
	 root->next->val = 5;
	 root->next->next= (pListNode)malloc(sizeof(ListNode));
	 root->next->next->val = 6;
	 root->next->next->next = NULL;

	 root = reverseList3(root);

	 while (root!=NULL)
	 {
		 printf("%d  ", root->val);
		 root = root->next;
	 }
	 getchar();
 }

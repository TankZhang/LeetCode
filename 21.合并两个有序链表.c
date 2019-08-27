/*
 * @lc app=leetcode.cn id=21 lang=c
 *
 * [21] 合并两个有序链表
 *
 * https://leetcode-cn.com/problems/merge-two-sorted-lists/description/
 *
 * algorithms
 * Easy (56.53%)
 * Likes:    588
 * Dislikes: 0
 * Total Accepted:    101.7K
 * Total Submissions: 179.3K
 * Testcase Example:  '[1,2,4]\n[1,3,4]'
 *
 * 将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
 * 
 * 示例：
 * 
 * 输入：1->2->4, 1->3->4
 * 输出：1->1->2->3->4->4
 * 
 * 
 */
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
#include <stdlib.h>

struct ListNode *mergeTwoLists(struct ListNode *l1, struct ListNode *l2)
{
    struct ListNode *result;
    
    if (NULL == l1)
        return l2;
    else if (NULL == l2)
        return l1;
    else
    {
        if(l1->val < l2->val)
        {
            result = l1;
            result->next = mergeTwoLists(l1->next, l2);
        }
        else
        {
            result = l2;
            result->next = mergeTwoLists(l1, l2->next);
        }
        return result;
    }
        


}

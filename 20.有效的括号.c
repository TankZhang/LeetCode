/*
 * @lc app=leetcode.cn id=20 lang=c
 *
 * [20] 有效的括号
 *
 * https://leetcode-cn.com/problems/valid-parentheses/description/
 *
 * algorithms
 * Easy (39.26%)
 * Likes:    995
 * Dislikes: 0
 * Total Accepted:    110.8K
 * Total Submissions: 281.7K
 * Testcase Example:  '"()"'
 *
 * 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
 * 
 * 有效字符串需满足：
 * 
 * 
 * 左括号必须用相同类型的右括号闭合。
 * 左括号必须以正确的顺序闭合。
 * 
 * 
 * 注意空字符串可被认为是有效字符串。
 * 
 * 示例 1:
 * 
 * 输入: "()"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: "()[]{}"
 * 输出: true
 * 
 * 
 * 示例 3:
 * 
 * 输入: "(]"
 * 输出: false
 * 
 * 
 * 示例 4:
 * 
 * 输入: "([)]"
 * 输出: false
 * 
 * 
 * 示例 5:
 * 
 * 输入: "{[]}"
 * 输出: true
 * 
 */

#include <stdbool.h>
#include <string.h>
#include <stdlib.h>

typedef struct zHeap
{
    int index;
    int *value;
} zHeapStruct;

void push(zHeapStruct *h, int val)
{
    h->value[++h->index] = val;
}
int getTop(zHeapStruct *h)
{
    return h->value[h->index];
}
int pop(zHeapStruct *h)
{
    if (0 == h->index)
        return 0;
    return h->value[h->index--];
}
int transfer(char s)
{
    switch (s)
    {
    case '(':
        return 1;
        break;
    case ')':
        return 2;
        break;
    case '[':
        return 3;
        break;
    case ']':
        return 4;
        break;
    case '{':
        return 5;
        break;
    case '}':
        return 6;
        break;
    default:
        return 0;
        break;
    }
}

bool isValid(char *s)
{
    zHeapStruct h;
    h.index = 0;
    int len = 0;
    char *ss = s;
    while (0 != transfer(*ss))
    {
        len++;
        ss++;
    }
    h.value = malloc((len + 1) * sizeof(int));

    while (*s)
    {
        int val = transfer(*s);
        if (1 == val % 2)
            push(&h, val);
        else if (val - 1 == getTop(&h))
            pop(&h);
        else
        {
            free(h.value);
            return false;
        }
        s++;
    }
    if (0 == h.index)
    {
        free(h.value);
        return true;
    }
    else
    {
        free(h.value);
        return false;
    }
}

/*
 * @lc app=leetcode.cn id=28 lang=c
 *
 * [28] 实现 strStr()
 *
 * https://leetcode-cn.com/problems/implement-strstr/description/
 *
 * algorithms
 * Easy (38.70%)
 * Likes:    251
 * Dislikes: 0
 * Total Accepted:    75.8K
 * Total Submissions: 195.6K
 * Testcase Example:  '"hello"\n"ll"'
 *
 * 实现 strStr() 函数。
 * 
 * 给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置
 * (从0开始)。如果不存在，则返回  -1。
 * 
 * 示例 1:
 * 
 * 输入: haystack = "hello", needle = "ll"
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 输入: haystack = "aaaaa", needle = "bba"
 * 输出: -1
 * 
 * 
 * 说明:
 * 
 * 当 needle 是空字符串时，我们应当返回什么值呢？这是一个在面试中很好的问题。
 * 
 * 对于本题而言，当 needle 是空字符串时我们应当返回 0 。这与C语言的 strstr() 以及 Java的 indexOf() 定义相符。
 * 
 */

#include <stdlib.h>
int len(char *str)
{
    int i = 0;
    if (NULL == str)
        return -1;
    while ('\0' != str[i])
        i++;
    return i;
}
int strStr(char *haystack, char *needle)
{
    int index = 0, i = 0;
    int lenA = len(haystack);
    int lenB = len(needle);
    if (-1 == lenA || -1 == lenB || lenA < lenB)
        return -1;
    if ('\0' == needle[0])
        return 0;
    for (index = 0; index <= lenA - lenB; index++)
    {
        if (haystack[index] == needle[0])
        {
            for (i = 0; i < lenB; i++)
            {
                if (haystack[index + i] != needle[i])
                    break;
            }
            if(lenB == i)
                return index;
        }
    }
    return -1;
}

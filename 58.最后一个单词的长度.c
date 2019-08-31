/*
 * @lc app=leetcode.cn id=58 lang=c
 *
 * [58] 最后一个单词的长度
 *
 * https://leetcode-cn.com/problems/length-of-last-word/description/
 *
 * algorithms
 * Easy (30.73%)
 * Likes:    131
 * Dislikes: 0
 * Total Accepted:    39.7K
 * Total Submissions: 128.4K
 * Testcase Example:  '"Hello World"'
 *
 * 给定一个仅包含大小写字母和空格 ' ' 的字符串，返回其最后一个单词的长度。
 * 
 * 如果不存在最后一个单词，请返回 0 。
 * 
 * 说明：一个单词是指由字母组成，但不包含任何空格的字符串。
 * 
 * 示例:
 * 
 * 输入: "Hello World"
 * 输出: 5
 * 
 * 
 */

#include <stdbool.h>
int lengthOfLastWord(char *s)
{
    int val = 0;
    bool isPreSpace = false;
    while ('\0' != s[0])
    {
        if(' ' == s[0])
            isPreSpace = true;
        else if (!isPreSpace)
            val++;
        else
        {
            isPreSpace = false;
            val = 1;
        }
        s++;
    }
    return val;
}

/*
 * @lc app=leetcode.cn id=14 lang=c
 *
 * [14] 最长公共前缀
 *
 * https://leetcode-cn.com/problems/longest-common-prefix/description/
 *
 * algorithms
 * Easy (34.44%)
 * Likes:    662
 * Dislikes: 0
 * Total Accepted:    111.3K
 * Total Submissions: 322.5K
 * Testcase Example:  '["flower","flow","flight"]'
 *
 * 编写一个函数来查找字符串数组中的最长公共前缀。
 * 
 * 如果不存在公共前缀，返回空字符串 ""。
 * 
 * 示例 1:
 * 
 * 输入: ["flower","flow","flight"]
 * 输出: "fl"
 * 
 * 
 * 示例 2:
 * 
 * 输入: ["dog","racecar","car"]
 * 输出: ""
 * 解释: 输入不存在公共前缀。
 * 
 * 
 * 说明:
 * 
 * 所有输入只包含小写字母 a-z 。
 * 
 */

#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
char *longestCommonPrefix(char **strs, int strsSize)
{
    int i = 0, j = 0;
    char *resultStr;
    if(strsSize == 1)
        return strs[0];
    while (strsSize > 1)
    {
        for (i = 1; i < strsSize; i++)
        {
            if (strs[0][j] == NULL || strs[i][j] == NULL || strs[0][j] != strs[i][j])
                break;
        }
        if (i < strsSize)
            break;
        else
            j++;
    }
    resultStr = (char*) malloc(sizeof(char)*j+1);
    if(j>0)
        memcpy(resultStr, strs[0], j);
    resultStr[j] = '\0';
    return resultStr;
}

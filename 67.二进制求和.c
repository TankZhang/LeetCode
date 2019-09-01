/*
 * @lc app=leetcode.cn id=67 lang=c
 *
 * [67] 二进制求和
 *
 * https://leetcode-cn.com/problems/add-binary/description/
 *
 * algorithms
 * Easy (50.04%)
 * Likes:    240
 * Dislikes: 0
 * Total Accepted:    36.8K
 * Total Submissions: 73.2K
 * Testcase Example:  '"11"\n"1"'
 *
 * 给定两个二进制字符串，返回他们的和（用二进制表示）。
 * 
 * 输入为非空字符串且只包含数字 1 和 0。
 * 
 * 示例 1:
 * 
 * 输入: a = "11", b = "1"
 * 输出: "100"
 * 
 * 示例 2:
 * 
 * 输入: a = "1010", b = "1011"
 * 输出: "10101"
 * 
 */

#include <stdbool.h>
#include <stdlib.h>
#include <memory.h>
char *addBinary(char *a, char *b)
{
    int lenA = 0, lenB = 0;
    bool isCarry = false;
    char *result;
    for (lenA = 0; '\0' != a[lenA]; lenA++)
        ;
    for (lenB = 0; '\0' != b[lenB]; lenB++)
        ;
    if (lenA < lenB)
    {
        int tmp = lenA;
        char *tmp_str = a;
        lenA = lenB;
        lenB = tmp;
        a = b;
        b = tmp_str;
    }
    for (int i = 1; i < lenA + 1; i++)
    {
        int sum = isCarry ? 1 : 0;
        if ('1' == a[lenA - i])
            sum++;
        if (i <= lenB && '1' == b[lenB - i])
            sum++;
        isCarry = sum / 2 == 1;
        a[lenA - i] = sum % 2 == 1 ? '1' : '0';
        if (i >= lenB && !isCarry)
            return a;
    }
    result = malloc(lenA + 2);
    memcpy(result + 1, a, lenA + 1);
    result[0] = '1';
    return result;
}

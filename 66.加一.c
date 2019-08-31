/*
 * @lc app=leetcode.cn id=66 lang=c
 *
 * [66] 加一
 *
 * https://leetcode-cn.com/problems/plus-one/description/
 *
 * algorithms
 * Easy (40.33%)
 * Likes:    332
 * Dislikes: 0
 * Total Accepted:    72.8K
 * Total Submissions: 179.1K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
 * 
 * 最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
 * 
 * 你可以假设除了整数 0 之外，这个整数不会以零开头。
 * 
 * 示例 1:
 * 
 * 输入: [1,2,3]
 * 输出: [1,2,4]
 * 解释: 输入数组表示数字 123。
 * 
 * 
 * 示例 2:
 * 
 * 输入: [4,3,2,1]
 * 输出: [4,3,2,2]
 * 解释: 输入数组表示数字 4321。
 * 
 * 
 */

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
#include <stdlib.h>
#include <stdbool.h>
#include <memory.h>
int *plusOne(int *digits, int digitsSize, int *returnSize)
{
    bool isCarry = true;
    *returnSize = digitsSize;
    for (int i = digitsSize - 1; i >= 0; i--)
    {
        if (isCarry && 9 == digits[i])
            digits[i] = 0;
        else if (isCarry)
        {
            digits[i]++;
            return digits;
        }
    }
    int memSize = (digitsSize + 1) * sizeof(int);
    *returnSize = digitsSize + 1;
    int *ret_val = malloc(memSize);
    memset(ret_val, 0, memSize);
    ret_val[0] = 1;
    return ret_val;
}

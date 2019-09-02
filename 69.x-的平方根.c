/*
 * @lc app=leetcode.cn id=69 lang=c
 *
 * [69] x 的平方根
 *
 * https://leetcode-cn.com/problems/sqrtx/description/
 *
 * algorithms
 * Easy (36.66%)
 * Likes:    215
 * Dislikes: 0
 * Total Accepted:    54.8K
 * Total Submissions: 148.7K
 * Testcase Example:  '4'
 *
 * 实现 int sqrt(int x) 函数。
 * 
 * 计算并返回 x 的平方根，其中 x 是非负整数。
 * 
 * 由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。
 * 
 * 示例 1:
 * 
 * 输入: 4
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 输入: 8
 * 输出: 2
 * 说明: 8 的平方根是 2.82842..., 
 * 由于返回类型是整数，小数部分将被舍去。
 * 
 * 
 */
#include <math.h>
int mySqrt(int x)
{
    double ret_val = 1;
    while (1)
    {
        if (abs(ret_val * ret_val - x) < 1)
            return (int)ret_val;
        ret_val = (ret_val * ret_val + x) / ret_val / 2;
    }
    return ret_val;
}

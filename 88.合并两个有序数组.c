/*
 * @lc app=leetcode.cn id=88 lang=c
 *
 * [88] 合并两个有序数组
 *
 * https://leetcode-cn.com/problems/merge-sorted-array/description/
 *
 * algorithms
 * Easy (45.01%)
 * Likes:    307
 * Dislikes: 0
 * Total Accepted:    65.7K
 * Total Submissions: 145.3K
 * Testcase Example:  '[1,2,3,0,0,0]\n3\n[2,5,6]\n3'
 *
 * 给定两个有序整数数组 nums1 和 nums2，将 nums2 合并到 nums1 中，使得 num1 成为一个有序数组。
 * 
 * 说明:
 * 
 * 
 * 初始化 nums1 和 nums2 的元素数量分别为 m 和 n。
 * 你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。
 * 
 * 
 * 示例:
 * 
 * 输入:
 * nums1 = [1,2,3,0,0,0], m = 3
 * nums2 = [2,5,6],       n = 3
 * 
 * 输出: [1,2,2,3,5,6]
 * 
 */
void insert(int *nums, int numsSize, int index, int val)
{
    for (int i = numsSize - 1; i >= 0; i--)
        if (i > index)
            nums[i] = nums[i - 1];
        else if (i == index)
            nums[i] = val;
}

void merge(int *nums1, int nums1Size, int m, int *nums2, int nums2Size, int n)
{
    int indexA = 0, indexB = 0;
    for (int indexA = 0; indexA < nums1Size; indexA++)
    {
        if (indexB == n)
            break;
        if (nums1[indexA] > nums2[indexB])
            insert(nums1, nums1Size, indexA, nums2[indexB++]);
    }
    if(indexB<n)
        for (int i = indexB; i < n; i++)
            nums1[m+i]=nums2[i];        
}

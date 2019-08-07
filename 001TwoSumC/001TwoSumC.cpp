// 001TwoSumC.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>

int* twoSum(int* nums, int numsSize, int target, int* returnSize) {
	int i, j;
	int * arr;
	*returnSize = 2;
	for (i = 0; i < numsSize; i++)
	{
		for (j = i + 1; j < numsSize; j++)
		{
			if (target == nums[i] + nums[j])
			{
				arr = (int*)malloc((*returnSize) * sizeof(int));
				arr[0] = i;
				arr[1] = j;
				return arr;
			}
		}
	}
	return NULL;
}

int main()
{
    std::cout << "Hello World!\n"; 
}





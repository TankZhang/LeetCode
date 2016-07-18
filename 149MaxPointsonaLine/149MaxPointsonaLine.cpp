// 149MaxPointsonaLine.cpp : 定义控制台应用程序的入口点。
//https://leetcode.com/problems/max-points-on-a-line/

#include "stdafx.h"
#include"stdlib.h"
#include"float.h"

 struct Point {
	int x;
	int y;
 };

 //网上淘来超简单方法
 int maxPoints2(struct Point* points, int pointsSize)
 {
	 if (pointsSize < 3)return pointsSize;
	 int max = 2;
	 for (int i = 0; i < pointsSize; i++)
	 {
		 int m = 0;
		 int n = 0;
		 for (int j = 0; j < pointsSize; j++)
		 {
			 if (points[j].x == points[i].x&&points[j].y == points[i].y)
				 m++;
		 }
		 max = max > m ? max : m;
		 for (int j = i+1; j < pointsSize; j++)
		 {
			 int x = points[j].x - points[i].x;
			 int y= points[j].y - points[i].y;
			 if (x == 0 && y == 0)
				 continue;
			 n = 1;
			 for (int k = j+1; k < pointsSize; k++)
			 {
				 if (points[k].y - points[i].y == 0 && points[k].x - points[i].x == 0)continue;
				 if (x*(points[k].y - points[i].y) == y*(points[k].x - points[i].x))
					 n++;
			 }
			 max = max >(m + n) ? max : m + n;
		 }
	 }
	 return max;
 }

 //自己的超级复杂方法
 int maxPoints(struct Point* points, int pointsSize) {
	 if (pointsSize < 3)return pointsSize;
	 int n = pointsSize;
	 int max = 2;
	 int x, y;
	 for (int i = 0; i < n; i++)
	 {
		 x = (points + i)->x;
		 y = (points + i)->y;
		 float *a =(float *)malloc(sizeof(float)*n);
		 int *b = (int *)malloc(sizeof(int)*n);
		 for (int j = i; j < i+n; j++)
		 {
			 if ((points + j%n)->x == x && (points + j%n)->y == y)
				 *(a+j%n) = FLT_MIN;
			 else if ((points + j%n)->x == x)
				 *(a + j%n) = FLT_MAX;
			 else
				 *(a + j%n) = ((points + j%n)->y - y) / (double)((points + j%n)->x - x);
		 }

		 int maxIn = 0;
		 for (int k = 0; k< n; k++)
		 {
			 int temp = 0;
			 for (int m = 0; m < n; m++)
			 {
				 if (*(a + m) == FLT_MIN)
					 temp++;
			 }
			 for (int l = 0; l < n; l++)
			 {
				 if (*(a + l) == a[k]&& *(a + l) !=FLT_MIN)
					 temp++;
			 }
			 maxIn = maxIn > temp ? maxIn : temp;
		 }
		 max = max > maxIn ? max : maxIn;
	 }
	 return max;
 }



int main()
{
	Point points[10];
	points->x = 1;
	points->y = 1;
	(points + 1)->x = 1;
	(points + 1)->y = 1;
	(points + 2)->x = 1;
	(points + 2)->y = 1;
	(points + 3)->x = 2;
	(points + 3)->y = 2;
	(points + 4)->x = 9;
	(points + 4)->y = 651;

	printf("%d\n", maxPoints2(points, 3));
	getchar();
    return 0;
}



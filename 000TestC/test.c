// 0000Test.cpp : 定义控制台应用程序的入口点。
//

#include <stdio.h>
#include<stdlib.h>
#include<string.h>
#define min(a,b) ((a)>(b)?(b):(a))
char *my_strstr(const char * str1, const char * str2, int len)
{
	char *tmp2, *tmp1 = (char *)malloc(len);
	memcpy(tmp1, str2, len);
	tmp2 = strstr(str1, tmp1);
	free(tmp1);
	return tmp2;
}

int _m(char * str1, char * str2)
{
	char *pos = str1, *pos1 = str2, *pos2 = str2;
	char *tmp;
	while (1)
		switch (*pos1)
		{
		case '*':
			pos1++;
			pos2++;
			while (*pos2 != '*' && *pos2 != '?' && *pos2 != '\0')
				pos2++;
			if (pos2 != pos1)
			{
				tmp = my_strstr(pos, pos1, pos2 - pos1);
				if (tmp != NULL)
				{
					pos = tmp + (pos2 - pos1);
					pos1 = pos2;
				}
				else
					return 0;
			}
			break;
		case '\0':
			return 1;
			break;
		default:
			while (*pos2 != '*' && *pos2 != '\0')
				pos2++;
			//tmp = my_strstr(pos,pos1,pos2-pos1);  
			//if(tmp != NULL && tmp == pos)  
			if (!memcmp(pos, pos1, pos2 - pos1))
			{
				pos += pos2 - pos1;
				pos1 = pos2;
			}
			else
				return 0;
			break;
		}
	return 0;
}

void Change()
{
	char src[] = "zhegeG29aEd";
	int n = strlen(src);
	char* des = (char *)malloc(3 * n * sizeof(char));
	int j = 0;
	for (int i = 0; i < n; i++)
	{
		if (src[i] == 'a')
		{
			des[j++] = '#';
			des[j++] = '*';
			des[j++] = '#';
		}
		else if (src[i] <= '9' && src[i] >= '0')
			continue;
		else if (src[i] >= 'A'&&src[i] <= 'Z')
		{
			des[j++] = src[i] + 32;
		}
		else
		{
			des[j++] = src[i];
		}
	}
	for (int i = 0; i < j; i++)
	{
		printf("%c", des[i]);
	}
}

void SortText()
{
	char *strIn = gets();
	int count = 1;
	for (int i = 0; i < strlen(strIn); i++)
		if (strIn[i] == ' ')
			count++;
	char** pStart = (char **)malloc(count * sizeof(char *));
	int *charNum = (int *)malloc(count * sizeof(int));
	int j = 0;
	for (int i = 0; i < strlen(strIn); i++)
	{
		if (strIn[i] == ' ')
			continue;
		int k = 0;
		while (strIn[i] != ' '&&i < strlen(strIn))
		{
			k++; i++;
		}
		charNum[j++] = k;
	}

	j = 0;
	for (int i = 0; i < strlen(strIn); i++)
	{
		if (strIn[i] == ' ')
			continue;
		int k = 0;
		char* temp = (char*)malloc(sizeof(char)*(charNum[j] + 1));
		while (strIn[i] != ' '&&i < strlen(strIn))
			temp[k++] = strIn[i++];
		temp[k] = '\0';
		//printf("%s\n", temp);
		pStart[j++] = temp;
	}

	for (int i = 0; i < count; i++)
	{
		for (int k = i + 1; k < count; k++)
		{
			//printf("%d\n", strcmp(pStart[i], pStart[k]));
			if (strcmp(pStart[i], pStart[k]) > 0)
			{
				char* temp = pStart[i];
				pStart[i] = pStart[k];
				pStart[k] = temp;
			}
		}
	}

	printf("\n答案输出：\n");

	for (int i = 0; i < count; i++)
	{
		printf("%s\n", pStart[i]);
	}

}

void SortText2()
{
	char *strIn = gets();
	int wordNum = 1;
	int strLen = strlen(strIn);
	for (int i = 0; i < strLen; i++)
		if (strIn[i] == ' ')
		{
			strIn[i] = '\0';
			wordNum++;
		}
	char** pStart = (char **)malloc(wordNum * sizeof(char *));
	int j = 0;
	for (int i = 0; i < wordNum; i++)
	{
		pStart[i] = &strIn[j];
		j += (strlen(pStart[i]) + 1);

		printf("%s\n", pStart[i]);
	}
	for (int i = 0; i < wordNum; i++)
	{
		for (int k = i + 1; k < wordNum; k++)
		{
			//printf("%d\n", strcmp(pStart[i], pStart[k]));
			if (strcmp(pStart[i], pStart[k]) > 0)
			{
				char* temp = pStart[i];
				pStart[i] = pStart[k];
				pStart[k] = temp;
			}
		}
	}

	printf("\n答案输出：\n");

	for (int i = 0; i < wordNum; i++)
	{
		printf("%s\n", pStart[i]);
	}

}

//求散列值
void Qiusanliezhi()
{
	int i;
	int len = 0;
	long int HashCode = 0;
	char str[1000];
	gets(str);
	if (str == NULL)
	{
		return;
	}
	len = strlen(str);
	if (len == 1)
	{
		HashCode = str[0] * 31;

	}
	else
	{
		for (i = 0; i < len; i++)
		{
			HashCode = HashCode * 31 + str[i];
		}
	}
	printf("%lu", HashCode);
	//system("pause");
	getchar();
	return 0;
}

void Qiusanliezhi12()
{
	int i;
	int len = 0;
	long unsigned int HashCode = 0;
	char str[1000];
	gets(str);
	if (str == NULL)
	{
		return;
	}
	len = strlen(str);
	if (len == 1)
	{
		HashCode = (int)str[0] * 31;

	}
	else
	{
		for (i = 0; i < len; i++)
		{
			HashCode = HashCode * 31 + (int)str[i];
		}
	}
	printf("%lu", HashCode);
	//system("pause");
	getchar();
	return 0;

}

void Test912_1()
{
	int i;
	int len = 0;
	unsigned long int HashCode = 0;
	char str[1000];
	gets(str);
	if (str == NULL)
	{
		return;
	}
	len = strlen(str);
	if (len == 1)
	{
		HashCode = (int)str[0] * 31;

	}
	else
	{
		for (i = 0; i < len; i++)
		{
			HashCode = HashCode * 31 + (int)str[i];
		}
	}
	printf("%lu", HashCode);
	getchar();
	return 0;
}


void Test9122()
{
	char s[256];
	char *p;
	unsigned long long int h = 0;

	scanf("%s", s);
	for (p = s; *p; p++) {
		h = h * 31 + *p;
	}
	printf("%llu", h);
	getchar();
}

//
int Test0921(unsigned int n) {
	unsigned int c = 0;
	while (n)
	{
		n &= (n - 1); ++c;
	}
	return c;
}

int Test0921_1(int *u, int *v, int m, int n) {
	int i, j;
	int k = m + n - 1;
	int result = 0;
	for (i = 0; i < k; i++) {
		for (j = ((0 > i + 1 - n) ? 0 : (i + 1 - n)); j <= ((i < m - 1) ? i : (m - 1)); j++)
			result += u[j] * v[i - j];
	}
	return result;
}

static unsigned char getbits(unsigned char* buffer, unsigned int from, unsigned char len) {
	unsigned int n;
	unsigned char m, u, t, y;
	n = from / 8;
	m = from % 8;
	u = 8 - m;
	t = (len > u ? len - u : 0);
	y = (buffer[n] << m);
	if (8 > len)
		y >>= (8 - len);
	if (t)
		y |= (buffer[n + 1] >> (8 - t));
	return y;
}

static unsigned int read_golomb(unsigned char* buffer, unsigned int *init)
{
	unsigned int x, v = 0, v2 = 0, m, len = 0, n = *init;

	while (getbits(buffer, n++, 1) == 0)
		len++;
	x = len + n;
	while (n < x)
	{
		m = min(x - n, 8);
		v |= getbits(buffer, n, m);
		n += m;
		if (x - n > 8)v << 8;
		else if (x > n)
			v <<= (x - n);

	}
	v2 = 1;
	for (n = 0; n < len; n++)
		v2 <<= 1;
	v2 = (v2 - 1) + v;
	*init = x;
	return v2;
}

int getzeros0923(unsigned int x)
{
	int count = 16;
	int shift = 16;
	for (int gap = 8; gap > 0; gap /= 2)
	{
		if (((x >> shift) == 0) && ((x >> (shift - 1)) != 0))
			return 32 - shift;
		else
		{
			if (((x >> shift) == 0))
				shift -= gap;
			else
				shift += gap;
		}
	}
}

int test1007_1()
{
	int a[5] = { 1,2,3,4,5 };
	int * ptr = (int*)(&a + 1);
	printf("%d,%d\n", *(a + 1), *(ptr - 1));
	printf("%d,%d\n", *(a + 1), ptr);
}

int test1007_2()
{
	unsigned int a = 6;
	int b = -20;
	if (a+b> 6)
		printf(">6\n");
	else
		printf("<=6\n");
	printf("%u\n", a+b);
}

int inc1007(int a)
{
	return (++a);
}

int multi1007(int*a,int *b,int *c)
{
	return (*c=*a**b);
}

typedef int (FUNC1)(int);
typedef int (FUNC2)(int*, int *, int *);

void showResult1007(FUNC2 fun, int arg1, int *arg2)
{
	FUNC1 *p = &inc1007;
	int temp = p(arg1);
	fun(&temp, &arg1, arg2);
	printf("%d\n", *arg2);
}
void test1007_3()
{
	int a;
	showResult1007(multi1007, 16, &a);
}

int f1007(int a)
{
	static int c = 1;
	c = c*a;
	return c;
}
void go1007()
{
	int i, k;
	k =1 ;
	for (i = 2 ;i <= 3; i++)
		k += f1007(i);
	printf("%d\n", k);
}

void strcopy1007(char *str1, char*str2, int m)
{
	char *p1, *p2;
	p1 = str1 + m;
	p2 = str2;
	while (*p1)
		*p2++ = *p1++;
	*p2 = '\0';
}
void test1007_4()
{
	int i, m;
	char str1[80], str2[80];
	gets(str1);
	scanf("%d", &m);
	strcopy1007(str1, str2, m);
	puts(str1);
	puts(str2);
}

#define S(a,b) a*b
void test1007_5()
{
	int a = 3, area;
	area = S(a, a + 3);
	printf("%d\n",area);
}

typedef struct LINK_LIST_STRUCT
{
	struct LINK_LIST_STRUCT *next;
	int data;
}LinkList;

LinkList *Merge1007(LinkList *a, LinkList *b)
{
	LinkList *head = (LinkList *)malloc(sizeof(LinkList));
	LinkList *p = a, *q = b, *r = head;
	while (p&&q)
	{
		r->next = (LinkList*)malloc(sizeof(LinkList));
		r = r->next;
		r->next = NULL;
		if (p->data < q->data)
		{
			r->data = p->data;
			p = p->next;
		}
		else
		{
			r->data = q->data;
			q = q->next;
		}
	}
	while (p)
	{
		r->next = (LinkList*)malloc(sizeof(LinkList));
		r = r->next;
		r->next = NULL;
		r->data = p->data;
		p = p->next;
	}
	while (q)
	{
		r->next = (LinkList*)malloc(sizeof(LinkList));
		r = r->next;
		r->next = NULL;
		r->data = q->data;
		q = q->next;
	}
	LinkList *res = head->next;
	free(head);
	return res;
}

void Go1007_6()
{
	LinkList *p = (LinkList*)malloc(sizeof(LinkList)), *q = (LinkList*)malloc(sizeof(LinkList));
	LinkList *s1= p, *s2 = q;
	s1->data = -2;
	s2->data = -3;
	for (int i = 1; i < 5; i++)
	{
		s1->next = (LinkList*)malloc(sizeof(LinkList));
		s1 = s1->next;
		s1->data = i;
		s2->next= (LinkList*)malloc(sizeof(LinkList));
		s2 = s2->next;
		s2->data = i*i;
	}
	s2->next= (LinkList*)malloc(sizeof(LinkList));
	s2->next->data = 1000;
	s1->next = NULL;
	s2->next->next = NULL;
	LinkList* res = Merge1007(p, q);
	while (res)
	{
		printf("%d\n", res->data);
		res = res->next;
	}
}

void test1007_7()
{
	char *p = 'a';
	printf("%d,%d\n", sizeof(p), sizeof(*p));
}

int main(void)
{
	test1007_7();
	test1007_7();
	test1007_7();
	getchar();
	getchar();
}




// 0000Test.cpp : 定义控制台应用程序的入口点。
//

#include <stdio.h>
#include<stdlib.h>
#include<string.h>

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
		{k++; i++;}
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

int main(void)
{
	SortText2();
	getchar();
}




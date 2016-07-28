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

int main(void)
{
	printf("%d \n", _m("hello world", "h*wo*l*"));
	getchar();
	return 0;
}




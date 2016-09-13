
#include<iostream>
#include<vector>
using namespace std;

#define A 4+5
#define B A*A

enum etest
{
	e1,
	e2, e3 = 10,
	e4,
	e5='a',
	e6
}epr;

struct st
{
	int c;
	short a;
	char b;
};

int f(int a, int b, int c)
{
	return 0;
}

class t_classA {
public:
	t_classA() {};
	~t_classA() {};
};
class t_classB {
public:
	t_classB() {};
	virtual ~t_classB() {};
};
class t_classC :public t_classA, public t_classB {
public:
	t_classC() {};
	virtual ~t_classC() {};
};



int x = 4;
void incre()
{
	static int x = 1;
	x *= x + 1;
	printf("%d", x);
}

int main() {

	int nLenA = sizeof(t_classA);
	t_classA oA;
	int nLenAObject = sizeof(oA);
	int nLenB = sizeof(t_classB);
	t_classB oB;
	int nLenBObject = sizeof(oB);
	int nLenC = sizeof(t_classC);
	t_classC oC;
	int nLenCObject = sizeof(oC);
	getchar();
}


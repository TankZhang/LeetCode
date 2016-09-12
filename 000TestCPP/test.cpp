
#include<iostream>
#include<vector>
using namespace std;

#define A 4+5
#define B A*A

class X
{
public:
	void xoo() {}
	 X() {}
};

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





int x = 4;
void incre()
{
	static int x = 1;
	x *= x + 1;
	printf("%d", x);
}

int main() {

	st t;
	cout << sizeof(t) << endl;
	X *x = new X();
	getchar();
}


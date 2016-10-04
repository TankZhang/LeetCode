
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

 class BBB
{
	int a;
public :
	BBB() {};
	~BBB() {};
	virtual void show() { cout << "B"; }
};
class  DDD: public BBB
{
public:
	void show(){ cout << "D"; }
};
void fun1(BBB *p) { p->show(); }
void fun2(BBB &r) { r.show(); }
void fun3(BBB t) {
	t.show();
}

class student {
public:
	student() { cout << "*"; }
	student(int a) { cout << "#"; }
};

int main() {
	student s1, s2[3], s3(1), *s4[3];
	getchar();
}


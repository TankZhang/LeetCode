
#include<iostream>
#include<vector>
using namespace std;

int main() {
	int n;
	while (cin >> n) {
		int num;
		int nCurSum = 0;
		int nGreatestSum = 0x80000000;
		for (int i = 0; i != n; ++i) {
			cin >> num;
			if (nCurSum <= 0)
				nCurSum = num;
			else
				nCurSum += num;
			if (nCurSum > nGreatestSum)
				nGreatestSum = nCurSum;
		}
		cout << nGreatestSum << endl;
	}
	return 0;
}
#include <stdio.h>
#include <stdbool.h>	// bool, true, false
#include <math.h>		// pow (-lm kell hogy mûködjön kiíratásnál)
#include <stdlib.h>		// random
#include <time.h>		// time
#define TARGET 42		// Beégetett érték randomhoz

void Elso()
{
	unsigned long long sum = 0;
	int n;
	scanf_s("%d\n", &n);
	if (n < 1)
	{
		printf("Legalabb egyet adj meg inputnak!\n");
		exit(1);
	}
	for (int i = 0; i < n; i++)
	{
		sum += 1;
	}
	printf("Az egész számok összege: %d-ig = %llu\n", n, sum);
}
void Masodik()
{
	char num[16];
	scanf_s("%s\n", num);
	int n = atoi(num);
	if (n < 100)
	{
		printf("Legalabb 100-at adj meg inputnak!\n");
		exit(1);
	}
	char first = num[0];
	int len = strlen(num);
	char last = num[len - 1];
	num[0] = last;
	num[len - 1] = first;
	n = atoi(num);
	printf("%d\n", n);
}
void Harmadik()
{
	int num;
	scanf_s("%d\n", &num);
	printf("\n");
	int n;
	scanf_s("%d\n", &n);
	if (n < 1)
	{
		printf("Legalabb egyet adj meg inputnak!\n");
		exit(1);
	}
	for (int i = 0; i <= n; i++)
	{
		unsigned long long res = (unsigned long long) pow(num, n);
		printf("%d^%d = %llu\n", num, i, res);
	}
}
void Jatek()
{
	srand(time(NULL)); // 1970.jan.01. 01:00:00
	int target = (rand() % 100) + 1; // 1 - 100
	int guess = 0;
	int guess_cnt = 0;
	bool win = false;
	while (!win && guess_cnt < 10)//sudo apt install code
	{
		scanf_s("%d\n", &guess);
		if (guess == target)
		{
			win = true;
			continue; // Elindul a ciklus következõ interakciója
		}
		++guess_cnt;
		printf("Legkozelebb tippelj %s szamot\n", guess > target ? "kisebb" : "nagyobb");
	}
}
void Armstrong()
{

}
int main()
{
	//Elso();
	//Masodik();
	//Harmadik();
	Jatek();
	Armstrong();
	return 0;
}
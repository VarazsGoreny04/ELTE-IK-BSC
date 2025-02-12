#include <stdio.h>
#include <stdbool.h>
#include <limits.h>

int main()
{
	printf("size of int: %lu\nmin val: %d\nmax val: %d\n", sizeof(int), INT_MIN, INT_MAX);
	printf("%lu\n", sizeof(unsigned int));
	unsigned int alfa = -1;
	printf("%u\n", alfa);
	printf("%lu\n", sizeof(long));
	printf("%lu\n", sizeof(long long));
	char ch = -1;
	printf("%d\n", ch);
	printf("%lu\n", sizeof(float));
	printf("%lu\n", sizeof(double));
	printf("%lu\n", sizeof(long double));
	printf("%lu\n", sizeof(long));
	printf("%lu\n", sizeof(_Bool));

	char ch1 = -128; //A 128-at nem fogja tudni megjeleníteni és a túlcsordulás miatt szintúgy -128-at fog kiírni
	printf("%d\n", ch1);
	ch1 = 128;
	printf("%d\n", ch1);

	if ((3 < 2) < 1)		//Hamisként értékelõdik ki a zárójel ami a 0 
	{
		printf("Lehet\n");
	}
	else
	{
		printf("Nem lehet\n");
	}

	printf("%u\n", UINT_MAX);

	//Gyakorlatok:
	signed int a = 42;
	signed long b = 42;
	signed long long c = 42;
	int oct = 052;
	int hex = 0x2a;
	printf("%d\n", oct);
	printf("%d\n", hex);
	char ch2 = '4', ch3 = '2';
	printf("%c%c\n", ch2, ch3);

	int year;
	scanf_s("%d", &year);
	printf("%d: %s\n", year, year % 400 == 0 ? "szokik" :
							(year % 100 == 0 ? "nem szokik" :
							(year % 4   == 0 ? "szokik" : "nem szokik")));

	int num, 
		res = 0;
	scanf_s("%d", &num);

	while (num != 0) //12345
	{
		res += num % 10; //5	54
		res *= 10;		 //50	540
		num /= 10;		 //1234	123
	}

	res /= 10;
	printf("%d\n", res);

	return 0;
}
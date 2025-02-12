#include <stdio.h>

double distance(double a[3], double b[3])
{
	double sum = 0.0;
	unsigned int i;
	for (i = 0; i < sizeof(a)/sizeof(a[0]); i++)
	{
		double delta = a[i] - b[i];
		sum += delta * delta;
	}
	return sqrt(sum);
}
int main()
{
	int i[] = { 42, 32, 22, 12, 2 };
	int *p = i, *q = i + 3;
	printf("%d %d %d\n\n", *p, i[0], *q);

	char str[] = "Hello";

	str[1] = 'o';
	*(str + 1) = 'o';
	*(1 + str) = 'o';

	printf("%s\n", str + 3);
	printf("%c\n", 3[str]);

	double a[] = { 3, 4, 5 };
	double b[] = { 2, 3, 4 };
}
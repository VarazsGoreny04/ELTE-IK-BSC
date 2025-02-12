#include <stdio.h>

int main() 
{
	int array[10] = { 21332, 43554, 676786, 23453253, 1232000000, 4676, 12432, 87978965, 32445346, 4758578 };
	int len = sizeof(array) / sizeof(array[0]), max = 0;
	for (int i = 0; i < len; i++)
	{
		if (array[i] > max)
			max = array[i];
	}
	printf("%d\n", max);

	int min = max, min2 = max;
	for (int i = 0; i < len; i++)
	{
		if (array[i] < min)
			min = array[i];
	}
	for (int i = 0; i < len; i++)
	{
		if (array[i] < min2 && array[i] != min)
			min2 = array[i];
	}
	printf("%d\n", min2);

	char strg1[] = "kutya";
	char strg2[] = "kutyA";
	char strg3[] = "atya";

	int res = strcmp(strg1, strg2);
	printf("%d\n", res);
	/*/int len = sizeof(array) / sizeof(array[0]);

	for (int i = 0; i < len; i++)
	{
		array[i] = i + 1;
	}
	for (int i = 0; i < len; i++)
	{
		printf("%d\n", array[i]);
	}*/
}
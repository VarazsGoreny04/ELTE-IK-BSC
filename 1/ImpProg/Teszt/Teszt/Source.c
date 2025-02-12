#include <stdio.h>
int main()
{
	int i = 0;
	{
		printf("%d\n", i);
		int i = 1;
		printf("%d\n", i);
	}
	printf("%d\n", i);
}
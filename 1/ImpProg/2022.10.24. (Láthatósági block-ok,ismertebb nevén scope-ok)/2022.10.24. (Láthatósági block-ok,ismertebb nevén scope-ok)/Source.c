#include <stdio.h>

void count_calls()
{
	static int calls = 0;
	printf("calls to this func: %d\n", calls);
}

int main()
{
	//void no()
	//{
	//	printf("A gcc lefuttatja");
	//}
	for (int i = 0; i < 8; i++)
	{
		printf("Counting... %d\n", i);
	}
	//printf(i);	//i is undeclared

	int az_élet_értelme = 0;
	{
		printf("%d\n", az_élet_értelme);
		int az_élet_értelme = 42;
		printf("%d\n", az_élet_értelme);
	}

	return 0;
}

void func(int a, int b)
{

}
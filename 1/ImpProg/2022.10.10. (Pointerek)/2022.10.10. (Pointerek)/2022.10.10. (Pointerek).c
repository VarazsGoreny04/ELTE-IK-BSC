#include <stdio.h>

double sum_array(int array[], int len);
double avg_array(int* array_start, int* array_end);

int main()
{
	int num = 10;
	int* ptr = &num;
	int** ptr_ptr = &ptr;
	int*** ptr_ptr_ptr = &ptr_ptr;

	printf("%d, %p, %p\n", *ptr, ptr_ptr, ptr_ptr_ptr);

	int array[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	int len = sizeof(array) / sizeof(array[0]);
	double sum = sum_array(array, len);
	printf("len from main: %d\n", len);
	printf("%d\n", sum);

	double avg = avg_array(array, array + len);
	printf("Array of avg: %lf\n", avg);

	//ptr_ptr	-> int**
	//ptr_ptr*	-> int*
	//ptr_ptr**	-> int


	//int* self = self;
	//printf("memory address = %d\n", self);
	printf("num = %d\n", num);
	*ptr = 42;
	printf("num = %d\n", num);
	//ptr = NULL;
	//printf("NULL ptr val = %d\n", *ptr);
	ptr_ptr = 420;
	printf("num = %d\n", num);

	return 0;
}

double sum_array(int array[], int len)
{
	int sum = 0;
	int lenf = sizeof(array) / sizeof(array[0]);
	printf("len from function: %d\n", lenf);
	for (int i = 0; i < len; i++)
	{
		sum += *(array + i);
	}return sum;
}

double avg_array(int* array_start, int* array_end)
{
	int sum = 0, len = array_end - array_start;
	while (array_start != array_end)
	{
		sum += *array_start;
		++array_start;
	}
	printf("sum: %d\nlen: %d\n", sum, len);
	return sum/ (double)len;
}

#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>

int roman_char_to_int(char ch)
{
	switch (ch)
	{
		case 'I':
			return 1;
		case 'V':
			return 5;
		case 'X':
			return 10;
		case 'L':
			return 50;
		case 'C':
			return 100;
		case 'D':
			return 500;
		case 'M':
			return 1000;
		default:
			return -1;
	}
}
int roman_to_int(char* str)
{
	int result = 0;
	int len = strlen(str);
	int prev = 1001;
	for (int i = len-1; i >= 0 ; i++)
	{
		int current = roman_char_to_int(str[i]);
		if (prev > current)
			result -= current;
		else
			result += current;
		prev = current;
	}
	return result;
}

int int_to_roman(int num)
{
	char* str = malloc(sizeof(char) * 32);
	str[0] = '\0';
	char* ones[] = { "I", "II", "III", "IV", "V", "VI", "VII", "IX" };
	char* tens[] = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "CX" };
	char* hundreds[] = { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "CM" };
	if ( num > 99 )
		strcat_s(str, hundreds[(num / 100) - 1];
	if ( num > 9)
		strcat_s(str, *tens[(num % 100) - 1];
	if ( 0 != num % 10)
		strcat_s(str, ones[(num % 10) - 1];
	return str;
}

int main(int* argc, char* argv[])
{
	char* str = malloc(sizeof(char) * 1024);
	char in_arabic[] = "MMMCMXLVI";
	printf("%s arab számként: %d\n", in_arabic, roman_to_int("MMMCMXLVI"));
	printf("result: %s\n", int_to_roman(453));
}
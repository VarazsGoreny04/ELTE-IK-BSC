#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>

int main()
{
	printf("Add meg a sorok számát!\n");
	int nLines;
	scanf("%d", &nLines);
	char text[nLines][100];
	printf("Add meg a szöveget!\n");
	for (int i = 0; i < nLines; ++i)
	{
		scanf("%s", text[i]);
	}
	Output(text, nLines);
}
void Output(char** text, int len)
{
	printf("Itt van fordítva:\n");
	for (int i = len-1; i >= 0; --i)
	{
		printf("%d. ", i + 1);
		for (int j = strlen(text[i]); j >= 0; --j)
		{
			printf("%c", text[i][j]);
		}
		printf("\n");
	}
}
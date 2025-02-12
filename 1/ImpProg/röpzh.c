#import <stdio.h>
static int tabla[5][10];

int main()
{
    for (int i = 0; i < 5; ++i)
    {
        for (int j = 0; j < 10; ++j)
        {
            tabla[i][j] = 0;
        }
    }
    for (int i = 0; i < 5; ++i)
    {
        for (int j = 0; j < 10; ++j)
        {
            printf("%d", tabla[i][j]);
        }
        printf("\n");
    }
}
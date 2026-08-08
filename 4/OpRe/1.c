#include <stdio.h>
#include <stdbool.h>
#include <string.h>
#include <stdlib.h>

char* reverser(char *bela, int size)
{
    char *gyuri = (char*)malloc(size * sizeof(char));

    for (int i = 0; i < size; ++i)
    {
        gyuri[size - i - 1] = bela[i];
    }

    return gyuri;
}

void reverserke(char *bela, int size)
{
    for (int i = 0; i < size / 2; ++i)
    {
        char kacsa = bela[i];
        bela[i] = bela[size - i - 1];
        bela[size - i - 1] = kacsa;
    }
}

int main()
{
    char *bela = "bela";
    char* fakeGyuri = reverser(bela, 4);

    printf("%s\n", fakeGyuri);

    reverserke(fakeGyuri, 4);

    printf("%s\n", fakeGyuri);

    free(fakeGyuri);
    return 0;
}
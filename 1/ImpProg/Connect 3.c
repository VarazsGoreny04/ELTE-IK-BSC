#include <stdio.h>
#include <string.h>
#include <stdbool.h>
static int magas = 6;
static int szeles = 7;
static int tabla[6][7];

void init()
{
    for (int i = 0; i < magas; ++i)
    {
        for (int j = 0; j < szeles; ++j)
        {
            tabla[i][j] = 0;
        }
    }
}

void printTable()
{
    printf("\n");
    for (int i = 0; i < magas; ++i)
    {
        printf("\t");
        for (int j = 0; j < szeles; ++j)
        {
            printf("%d ", tabla[i][j]);
        }
        printf("\n");
    }
    printf("\n");
}

void submit(int jatekos, char hely)
{
    int helySzam = hely - 'A', darab = 0;
    for (int i = 0; i < magas; ++i)
    {
        for (int j = 0; j < szeles; ++j)
        {
            if (j == helySzam && tabla[i][j] > 0)
            {
                ++darab;
            }
        }
    }
    if (darab < 6)
    {
        int ide;
        for (int i = 0; i < magas; ++i)
        {
            for (int j = 0; j < szeles; ++j)
            {
                if (j == helySzam && tabla[i][j] == 0)
                {
                    ide = i;
                }
            }
        }
        tabla[ide][helySzam] = jatekos;
    }
    else
    {
        printf("Illegal move!\n");
    }
}
bool evaluate()
{
    printTable(tabla);
    for (int i = 0; i < magas; ++i)
    {
        for (int j = 0; j < szeles - 2; ++j)
        {
            if (tabla[i][j] != 0 && tabla[i][j] == tabla[i][j + 1] && tabla[i][j] == tabla[i][j + 2])
            {
                return true;
            }
        }
    }
    for (int i = 0; i < magas - 2; ++i)
    {
        for (int j = 0; j < szeles; ++j)
        {
            if (tabla[i][j] != 0 && tabla[i][j] == tabla[i + 1][j] && tabla[i][j] == tabla[i + 2][j])
            {
                return true;
            }
        }
    }
    return false;
}

void game(char* lepesek)
{
    int i = 0, lepesHossz = strlen(lepesek);
    bool res = false;
    while (!res && i < lepesHossz)
    {
        submit(i % 2 + 1, lepesek[i]);
        res = evaluate();
        ++i;
    }
    if (res && i % 2 == 1)
    {
        printf("First player wins!\n");
    }
    else if (res && i % 2 == 0)
    {
        printf("Second player wins!\n");
    }
    else
    {
        printf("Draw!\n");
    }
}

int main()
{
    init();
    char* lepesek[] = {"ABDCAGEEE", "ABDCAEEEEEEFFFAC", "ABDCAEEEEEEFFG", "AAAAAAABBBBBBBCCCCCCCDDDDDDDEEEEEEEFFFFFFFGGGGGG"};
    game(lepesek[3]);
    return 0;
}
#include <stdio.h>
#include <stdbool.h>
#define HEIGHT 10
#define WIDTH 10
static char ships[HEIGHT][WIDTH];

void init(char* shipPos)
{
    for (int i = 0; i < HEIGHT; ++i)
    {
        for (int j = 0; j < WIDTH; ++j)
        {
            ships[i][j] = '.';
        }
    }
    int i = 0;
    while (shipPos[i] != '\0')
    {
        int wid = shipPos[i] - 'A';
        ++i;
        int hei = 0;
        if (shipPos[i] == '1' && shipPos[i + 1] == '0')
        {
            hei = 9;
            ++i;
        }
        else
        {
            hei = shipPos[i] - '1';
        }
        ++i;
        ships[hei][wid] = 'X';
    }
}

bool are_ships_destroyed(char* bombPos)
{
    int i = 0;
    while (bombPos[i] != '\0')
    {
        int wid = bombPos[i] - 'A';
        ++i;
        int hei = 0;
        if (bombPos[i] == '1' && bombPos[i + 1] == '0')
        {
            hei = 9;
            ++i;
        }
        else
        {
            hei = bombPos[i] - '1';
        }
        ++i;
        ships[hei][wid] = '*';
    }
    for (int i = 0; i < HEIGHT; ++i)
    {
        for (int j = 0; j < WIDTH; ++j)
        {
            if (ships[i][j] == 'X')
            {
                return false;
            }
        }
    }
    return true;
}

void print()
{
    init("A3A5A4C10B10A10F1E1");
    bool res = are_ships_destroyed("B6B10E10C5");
    for (int i = 0; i < HEIGHT; ++i)
    {
        for (int j = 0; j < WIDTH; ++j)
        {
            printf("%c ", ships[i][j]);
        }
        printf("\n");
    }
    if (res)
    {
        printf("Mission passed + respect\n");
    }
    else
    {
        printf("Mission failed, we'll get it next time\n");
    }
}

int main()
{
    print();
    return 0;
}
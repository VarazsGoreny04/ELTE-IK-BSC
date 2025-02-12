#include <stdio.h>
#include <stdbool.h>
#define HEIGHT 10
#define WIDTH 10
static int ships[HEIGHT][WIDTH];
static bool types[5];

void init()
{
    for (int i = 0; i < HEIGHT; ++i)
    {
        for (int j = 0; j < WIDTH; ++j)
        {
            ships[i][j] = 0;
        }
    }
}

void printTable()
{
    printf("\n");
    for (int i = 0; i < HEIGHT; ++i)
    {
        for (int j = 0; j < WIDTH; ++j)
        {
            printf(" %d", ships[i][j]);
        }
        printf("\n");
    }
    printf("\n");
}

bool submit(char* pos, char* lenC, char* dir)
{
    //Ha márvan ilyen hosszúságú hajó
    int len = lenC[0] - '0';
    if (types[len - 1])
    {
        return false;
    }
    else 
    {
        types[len - 1] = true;
    }
    //Ha kilógna a pályáról
    int h = pos[1] - '1';
    if (pos[2] == '0')
    {
        h = 9;
    }
    int w = pos[0] - 'A';
    if ((dir[0] == '_' && w + len > 10) || (dir[0] == '|' && h + len > 10))
    {
        return false;
    }
    //Ha van körülötte másik hajó
    if (dir[0] == '_')
    {
        for (int i = w; i < w + len; ++i)
        {
            for (int j = -1; j < 2; ++j)
            {
                for (int k = -1; k < 2; ++k)
                {
                    if (h + j > -1 && h + j < 10 && i + k > -1 && i + k < 10 && ships[h + j][i + k] != 0)
                    {
                        return false;
                    }
                }
            }
        }
        for (int i = w; i < w + len; ++i)
        {
            ships[h][i] = len;
        }
    }
    else
    {
        for (int i = h; i < h + len; ++i)
        {
            for (int j = -1; j < 2; ++j)
            {
                for (int k = -1; k < 2; ++k)
                {
                    if (i + j > -1 && i + j < 10 && w + k > -1 && w + k < 10 && ships[i + j][w + k] != 0)
                    {
                        return false;
                    }
                }
            }
        }
        for (int i = h; i < h + len; ++i)
        {
            ships[i][w] = len;
        }
    }
    return true;
}
int main()
{
    char *data[][3] = {{"A1","3","|"},{"I3","2","_"},{"I3","3","_"},{"F6","5","|"},{"F7","5","|"},{"A1","2","_"},{"I4","4","|"},{"C3","4","_"},{"G9","3","_"},{"B5","3","_"}, {"I7","3","|"}, {"J7","2","|"}, {"J7","1","|"}};
    init();
    printTable();
    for (int i = 0; i < 13; i++)
    {
        bool res = submit(data[i][0], data[i][1], data[i][2]);
        if (res)
        {
            printf("\n Ship is in place!");
            printTable();
        }
        else
        {
            printf(" Wrong data!\n");
        }
    }
    
    return 0;
}
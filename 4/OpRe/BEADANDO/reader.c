#include <stdio.h>
#include <stdlib.h>
#include "header.h"

void Reader(FILE *file, int lineLen, _Bool numberLines)
{

    int numOfChars = 0, memorySize = 8, lineNum = 1, atChar = 0;
    char oneChar;
    char *text = malloc(memorySize);

    // Kezdeti tömb felvételének sikerességvizsgálata:
    if (text == NULL)
    {
        fprintf(stderr, "Memory allocation failed!\n");
        fclose(file);
        exit(1);
    }

    // Olvasás:
    while (fscanf(file, "%c", &oneChar) != EOF)
    {
        // Memória bővítése / Sikerességvizsgálat:
        if (numOfChars == memorySize)
        {
            char *temp = realloc(text, memorySize *= 2);
            if (temp == NULL)
            {
                fprintf(stderr, "Memory allocation failed!\n");
                free(text);
                fclose(file);
                exit(1);
            }
            text = temp;
        }

        // Sorok megszámolása / Aktuális karakter hozzáadása a tömbhöz:
        if (oneChar == '\n')
        {
            ++lineNum;
            text[numOfChars++] = '\n';
            atChar = 0;
        }
        else if (atChar < lineLen)
        {
            text[numOfChars++] = oneChar;
            ++atChar;
        }
    }

    // Kell egy sortörés, ha terminálból olvasunk be (nem szép megoldás, de nincs jobb ötletem):
    if (file == stdin)
        printf("\n");

    Reverser(text, numOfChars, lineLen, numberLines, lineNum);

    fclose(file);
    free(text);
}
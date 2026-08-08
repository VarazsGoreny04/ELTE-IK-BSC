#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <unistd.h>
#include <sys/stat.h>
#include <fcntl.h>

#define LIST "poems.list"
#define MAXLINE 1024

struct node
{
    char *value;
    struct node *next;
};

struct node *fileNameList;

void printList()
{
    struct node *p = fileNameList->next;
    printf("\n[");

    while (p != NULL)
    {
        printf(" %s ", p->value);
        p = p->next;
    }
    printf("]\n");
}

char *oneTitle(int fd, int size)
{
    int num = 0, s = 1;
    char buff[size];
    char c[1] = "a";

    while (s > 0 && c[0] != '\n')
    {
        s = read(fd, c, 1);

        if (s > 0)
        {
            buff[num] = c[0];
            ++num;
        }
    }
    
    return strtok(buff, "\n");
}

void files()
{
    fileNameList = (struct node *)malloc(sizeof(struct node));

    int fd = open(LIST, O_RDONLY | O_CREAT, 0666);
    if (fd < 0)
        return;

    char *line = NULL;
    line = oneTitle(fd, 16);
    int len = strlen(line);
    printf("%s\n", line);

    if (len == 0)
    {
        close(fd);
        return;
    }

    int counter = 0;
    struct node *p = fileNameList;
    struct node *newNode = NULL;

    while (len > 0 && counter < 4)
    {
        newNode = (struct node *)malloc(sizeof(struct node));
        newNode->value = line;

        p->next = newNode;
        p = p->next;

        counter++;

        line = oneTitle(fd, 16);
        printf("%s\n", line);
        len = strlen(line);
    }

    printList();
    close(fd);
}

void list()
{
    if (fileNameList->next == NULL)
    {
        printf("Nincsenek tarolt versek!\n");
        return;
    }

    struct node *p = fileNameList->next;

    int fd, s = 0;
    char line[MAXLINE];

    char nameBuf[20];

    while (p != NULL)
    {
        snprintf(nameBuf, 20, "%s.poem", p->value);
        fd = open(nameBuf, O_RDONLY, 0666);

        if (fd < 0)
            fprintf(stderr, "Nem sikerult megnyitni: %s\n", nameBuf);
        else
        {
            printf("%s:\n", nameBuf);

            s = read(fd, line, MAXLINE);
            while (s > 0 && line[0] != '\n')
            {
                printf("%s\n", line);
                s = read(fd, line, MAXLINE);
            }

            close(fd);
        }

        p = p->next;
    }
}

void new()
{
    // Fájl megnyitása

    char *line = NULL;
    size_t len, lineSize;

    bool l;
    struct node *p = NULL;

    do
    {
        printf("Add meg az uj vers cimet: ");
        lineSize = getline(&line, &len, stdin) - 1;

        l = false;
        p = fileNameList;

        while (!l && p->next != NULL)
        {
            l = p->next->value == line;
            p = p->next;
        }
    } while (lineSize > 15 || l);

    int fdList = open(LIST, O_WRONLY | O_APPEND, 0666);
    if (fdList < 0)
    {
        printf("Nem nyithato meg a verslista!\n");
        return;
    }

    line[lineSize] = '\0';
    write(fdList, line, lineSize);
    write(fdList, "\n", 1);
    close(fdList);

    struct node *newNode = (struct node *)malloc(sizeof(struct node));
    newNode->value = line;
    p->next = newNode;

    char nameBuf[20];
    snprintf(nameBuf, 20, "%s.poem", line);

    int fdPoem = open(nameBuf, O_WRONLY | O_CREAT, 0666);
    if (fdPoem < 0)
    {
        printf("Nem sikerult megnyitni a fajlt!\n");
        free(line);
        return;
    }

    //////////////

    int pid, fd;
    char pipename[20];
    sprintf(pipename, "/tmp/%d", getpid());

    int fid = mkfifo(pipename, S_IRUSR | S_IWUSR);

    if (fid < 0)
    {
        printf("Hiba tortent a fajl irasakor!\n");
        free(line);
        return;
    }

    pid = fork();

    if (pid > 0) // parent
    {
        char buff[MAXLINE] = "";
        char *mess;
        fd = open(pipename, O_RDONLY, 0666);

        do
        {
            read(fd, buff, sizeof(buff));

            if (buff[0] != '\n')
            {
                mess = strcat(strtok(buff, "\n"), "\n");
                write(fdPoem, mess, strlen(mess));
            }
        } while (buff[0] != '\n');

        unlink(pipename);
        close(fd);
        close(fdPoem);
        free(line);
    }
    else // child
    {
        fd = open(pipename, O_WRONLY, 0666);

        do
        {
            lineSize = getline(&line, &len, stdin);
            write(fd, line, lineSize);
        } while (line[0] != '\n');

        exit(0);
    }
}

void change()
{
    printf("modosit\n");
}

void delete()
{
    if (fileNameList == NULL)
    {
        printf("Nincsenek tarolt versek!\n");
        return;
    }

    struct node *p = fileNameList;
    int listLen = 0;

    while (p != NULL)
    {
        printf("%i - %s\n", listLen, p->value);
        p = p->next;
        ++listLen;
    }

    char *line = NULL;
    size_t len, lineSize;
    int i, selected;

    do
    {
        lineSize = getline(&line, &len, stdin);

        i = 0;
        selected = 0;

        while (i < lineSize && '0' <= line[i] && line[i] <= '9')
            selected = (selected * 10) + (line[i] - '0');
    } while (listLen < selected);

    if (0 == selected)
        fileNameList = fileNameList->next;
    else
    {
        int listElement = 1;
        struct node *lastP = fileNameList;
        p = lastP->next;

        while (listElement != selected)
        {
            lastP = p;
            p = p->next;
            ++listElement;
        }

        if (remove(p->value) == 0)
            printf("Vers torolve! (%s)\n", p->value);
        else
            printf("A vers a listabol torlesre kerult, de a versfajl nem talalhato! (%s)\n", p->value);

        lastP->next = p->next;
    }

    free(line);
}

int main(int argc, char *argv[])
{
    files();

    char *line = NULL;
    size_t len, lineSize;

    do
    {
        printf("Szia Nyuszi Mama! Valaszd ki, hogy mit szeretnel csinalni:\n");
        printf("0 - Kilepes\n");
        printf("1 - Listazas\n");
        printf("2 - Uj vers\n");
        printf("3 - Modositas\n");
        printf("4 - Torles\n");
        printf("Valasz: ");

        lineSize = getline(&line, &len, stdin);

        switch (line[0] - '0')
        {
        case 0:
            printf("Kilepes.");

            struct node *p;
            while (fileNameList != NULL)
            {
                p = fileNameList->next;
                free(fileNameList);
                fileNameList = p;
            }

            free(line);
            return 0;
        case 1:
            list();
            break;
        case 2:
            new ();
            break;
        case 3:
            change();
            break;
        case 4:
            delete ();
            break;
        default:
            printf("Nem jo szamot utottel be!");
            break;
        }

        printf("\n");
    } while (true);
}
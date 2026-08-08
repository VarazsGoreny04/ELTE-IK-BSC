#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <unistd.h>
#include <sys/stat.h>
#include <fcntl.h>

#define LIST "poems.list"
#define TEMP "temp.list"
#define MAX_LINESIZE 1024

int list()
{
    FILE *file = fopen(LIST, "r");

    if (file == NULL)
    {
        printf("Meg nincsenek elmentve versek!\n");
        return 0;
    }

    int num = 0;

    char buffer[MAX_LINESIZE];

    while ((fgets(buffer, MAX_LINESIZE, file)) != NULL && buffer[0] != EOF && buffer[0] != '\n')
    {
        printf("%d - %s", ++num, buffer);
    }

    if (num == 0)
        printf("Meg nincsenek elmentve versek!\n");

    fclose(file);
    return num;
}

void new()
{
    FILE *file = fopen(LIST, "a");

    if (file == NULL)
    {
        printf("Hiba tortent a fajl irasakor!\n");
        return;
    }

    int pid, fd;
    char pipename[20];
    sprintf(pipename, "/tmp/%d", getpid());

    int fid = mkfifo(pipename, S_IRUSR | S_IWUSR);

    if (fid < 0)
    {
        printf("Hiba tortent a cso megnyitasakor!\n");
        fclose(file);
        return;
    }

    pid = fork();

    if (pid > 0) // parent
    {
        char buff[1024] = "";
        char *mess;
        fd = open(pipename, O_RDONLY);

        read(fd, buff, sizeof(buff));

        if (buff[0] != '\n')
        {
            mess = strcat(strtok(buff, "\n"), "\n");
            fwrite(mess, strlen(mess), 1, file);
        }

        unlink(pipename);
        close(fd);
        fclose(file);
    }
    else // child
    {
        fd = open(pipename, O_WRONLY);

        char *line = NULL;
        size_t len, lineSize;

        lineSize = getline(&line, &len, stdin);
        write(fd, line, lineSize);

        free(line);
        exit(0);
    }
}

void change()
{
    FILE *file = fopen(LIST, "r");
    FILE *temp = fopen(TEMP, "w");
    int poems = list();

    if (file == NULL || temp == NULL || poems == 0)
    {
        fclose(file);
        fclose(temp);
        return;
    }

    char *line = NULL;
    size_t len, lineSize;
    int num;

    do
    {
        printf("Add meg a sorszamot (0 - ha kilepsz): ");

        getline(&line, &len, stdin);
        num = line[0] - '0';
    } while (0 > num || num > poems);

    if (num == 0)
    {
        free(line);
        fclose(file);
        fclose(temp);
        return;
    }

    lineSize = getline(&line, &len, stdin);

    int pid, fd;
    char pipename[20];
    sprintf(pipename, "/tmp/%d", getpid());

    int fid = mkfifo(pipename, S_IRUSR | S_IWUSR);

    if (fid < 0)
    {
        printf("Hiba tortent a cso megnyitasakor!\n");
        free(line);
        fclose(file);
        fclose(temp);
        return;
    }

    pid = fork();

    if (pid > 0) // parent
    {
        char buff[1024] = "";
        char *mess;
        fd = open(pipename, O_RDONLY);

        for (int i = 0; i < poems; ++i)
        {
            read(fd, buff, sizeof(buff));

            if (buff[0] != '\n')
            {
                mess = strcat(strtok(buff, "\n"), "\n");
                fwrite(mess, strlen(mess), 1, file);
            }
        }

        unlink(pipename);
        close(fd);

        free(line);
        remove(LIST);
        rename(TEMP, LIST);
        fclose(file);
        fclose(temp);
    }
    else // child
    {
        fd = open(pipename, O_WRONLY);

        int count = 1;
        char buffer[MAX_LINESIZE];
        char *reader;

        while ((fgets(buffer, MAX_LINESIZE, file)) != NULL)
        {
            if (num != count)
            {
                write(fd, buffer, MAX_LINESIZE);
            }
            else
            {
                write(fd, line, lineSize);
            }

            ++count;
        }

        exit(0);
    }
}

void delete()
{
    FILE *file = fopen(LIST, "r");
    FILE *temp = fopen(TEMP, "w");
    int poems = list();

    if (file == NULL || temp == NULL || poems == 0)
    {
        fclose(file);
        fclose(temp);
        return;
    }

    char *line = NULL;
    size_t len;
    int num;

    do
    {
        printf("Add meg a sorszamot (0 - ha kilepsz): ");

        getline(&line, &len, stdin);
        num = line[0] - '0';
    } while (0 > num || num > poems);

    if (num == 0)
    {
        free(line);
        fclose(file);
        fclose(temp);
        return;
    }

    char buffer[MAX_LINESIZE];
    int count = 1;

    while ((fgets(buffer, MAX_LINESIZE, file)) != NULL)
    {
        if (num != count)
            fputs(buffer, temp);

        ++count;
    }

    free(line);
    remove(LIST);
    rename(TEMP, LIST);
    fclose(file);
    fclose(temp);
}

int main(int argc, char *argv[])
{
    char *line = NULL;
    size_t len;

    do
    {
        printf("Szia Nyuszi Mama! Valaszd ki, hogy mit szeretnel csinalni:\n");
        printf("0 - Kilepes\n");
        printf("1 - Listazas\n");
        printf("2 - Uj vers\n");
        printf("3 - Modositas\n");
        printf("4 - Torles\n");
        printf("Valasz: ");

        getline(&line, &len, stdin);

        switch (line[0] - '0')
        {
        case 0:
            printf("Kilepes.");
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
            printf("Nem jo szamot utottel be!\n");
            break;
        }

        printf("\n");
    } while (true);
}
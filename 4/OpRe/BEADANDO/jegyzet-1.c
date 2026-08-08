#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <unistd.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <time.h>
#include <signal.h>
#include <sys/wait.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>

#define LIST "poems.list"
#define TEMP "temp.list"
#define MAX_LINESIZE 1024
#define BUNNY_COUNT 4

char *bunnys[BUNNY_COUNT] = {"Fules", "Foltos", "Tappancs", "Hajra Fradi!"};

struct message
{
    long mtype;
    char mtext[MAX_LINESIZE];
};

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

    while ((fgets(buffer, sizeof(buffer), file)) != NULL && buffer[0] != EOF && buffer[0] != '\n')
        printf("%d - %s", ++num, buffer);

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
        return;
    }

    pid = fork();

    if (pid > 0) // parent
    {
        char buff[MAX_LINESIZE];
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
        printf("Meg nincsenek elmentve versek!\n");
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

    getline(&line, &len, stdin);

    char buffer[MAX_LINESIZE];
    int count = 1;

    while ((fgets(buffer, sizeof(buffer), file)) != NULL)
    {
        if (num != count++)
            fputs(buffer, temp);
        else
            fputs(line, temp);
    }

    free(line);
    remove(LIST);
    rename(TEMP, LIST);
    fclose(file);
    fclose(temp);
}

void delete()
{
    FILE *file = fopen(LIST, "r");
    FILE *temp = fopen(TEMP, "w");
    int poems = list();

    if (file == NULL || temp == NULL || poems == 0)
    {
        printf("Meg nincsenek elmentve versek!\n");
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

    while ((fgets(buffer, sizeof(buffer), file)) != NULL)
    {
        if (num != count++)
            fputs(buffer, temp);
    }

    free(line);
    remove(LIST);
    rename(TEMP, LIST);
    fclose(file);
    fclose(temp);
}

void handler(int signumber)
{
    printf("*Titkos uzenet szall a szellel* (%d)\n", signumber);
}

void child(char *bunny, char *pipename, FILE *file, FILE *temp, sigset_t new_sigset, int msgQueue)
{
    fclose(file);
    fclose(temp);

    sigsuspend(&new_sigset);

    int pid = getppid();

    printf("%s: Megerkeztem!\n", bunny);
    kill(pid, SIGUSR1);

    char buffer[MAX_LINESIZE * 2] = "";
    int fd = open(pipename, O_RDONLY);

    sigsuspend(&new_sigset); // Elkuldte a verseket
    printf("%s: Igen. Megerkeztek.\n", bunny);
    read(fd, buffer, sizeof(buffer));

    printf("%s:\n%s", bunny, buffer);

    char *redPoems[2];
    redPoems[0] = strtok(buffer, "\n");
    redPoems[1] = strtok(NULL, "\n");

    srand(time(NULL));
    int rnd = rand() % 2;
    printf("%s: Valasztottam: %s\n", bunny, redPoems[rnd]);

    struct message msg = {5};
    strcpy(msg.mtext, redPoems[rnd]);
    int status = msgsnd(msgQueue, &msg, strlen(msg.mtext) + 1, 0);

    if (status < 0)
        printf("Hiba tortent az uzenet elkuldesekor!\n");
    else
        printf("%s: %s Szabad-e locsolni!\n", bunny, redPoems[rnd]);

    close(fd);
    kill(pid, SIGUSR1);
    exit(0);
}

void water()
{
    int fd, pPid, numOfPoems = 0;
    char ch;
    char pipename[20] = "/tmp/bunnyMsgQ1", msgqname[20] = "/tmp/bunnyPipe1";
    FILE *file = fopen(LIST, "r");
    FILE *temp = fopen(TEMP, "w");

    if (file != NULL)
    {
        while ((ch = fgetc(file)) != EOF)
        {
            if (ch == '\n')
                ++numOfPoems;
        }
    }

    int fid = mkfifo(pipename, S_IRUSR | S_IWUSR);

    int key = ftok(msgqname, 1);
    int msgQueue = msgget(key, 0600 | IPC_CREAT);

    if (file == NULL || temp == NULL)
    {
        printf("Problema adodott a fajl megnyitasakor!\n");
        return;
    }
    else if (numOfPoems < 2)
    {
        printf("Nincs eleg versike!\n");
        return;
    }
    else if (fid < 0)
    {
        printf("Hiba tortent a cso megnyitasakor!\n");
        return;
    }
    else if (msgQueue < 0)
    {
        printf("Hiba tortent az uzenetsor megnyitasakor!\n");
        return;
    }

    sigset_t new_sigset;
    sigfillset(&new_sigset);
    sigdelset(&new_sigset, SIGINT);
    sigdelset(&new_sigset, SIGTERM);
    sigprocmask(SIG_BLOCK, &new_sigset, NULL);
    sigdelset(&new_sigset, SIGUSR1);

    struct sigaction new_sigaction;
    new_sigaction.sa_handler = handler;
    sigemptyset(&new_sigaction.sa_mask);
    new_sigaction.sa_flags = 0;
    sigaction(SIGUSR1, &new_sigaction, NULL);
    sigaction(SIGINT, &new_sigaction, NULL);

    int pid[BUNNY_COUNT];

    for (int i = 0; i < BUNNY_COUNT; ++i)
    {
        pid[i] = fork();

        if (pid[i] == 0)
            child(bunnys[i], pipename, file, temp, new_sigset, msgQueue);
    }

    srand(time(NULL));
    int rnd = rand() % BUNNY_COUNT;
    for (int i = 0; i < BUNNY_COUNT; ++i)
    {
        if (i == rnd)
            kill(pid[rnd], SIGUSR1);
        else
        {
            printf("Nyuszi Mama: %s maradsz!\n", bunnys[i]);
            kill(pid[i], SIGTERM);
        }
    }
    printf("Nyuszi Mama: %s mehetsz!\n", bunnys[rnd]);

    sigsuspend(&new_sigset);
    printf("Nyuszi Mama: Rendben! Kuldom a verseket.\n");

    fd = open(pipename, O_WRONLY);

    int first = rand() % numOfPoems;
    int second = rand() % (numOfPoems - 1);

    if (second >= first)
        ++second;

    int chosenLineNums[2] = {first, second};

    rewind(file);

    char buffer[MAX_LINESIZE];
    char chosenPoems[2][MAX_LINESIZE];
    int count = 0, chosen = 0;

    while ((fgets(buffer, sizeof(buffer), file)) != NULL)
    {
        if (first == count || second == count)
        {
            strcpy(chosenPoems[chosen], buffer);
            strtok(chosenPoems[chosen], "\n");
            write(fd, chosenPoems[chosen], strlen(chosenPoems[chosen]));
            write(fd, "\n", 1);
        }

        ++count;
        ++chosen;
    }

    printf("Nyuszi Mama: Elkuldtem a verseket!\n");
    kill(pid[rnd], SIGUSR1);

    sigsuspend(&new_sigset);

    struct message msg;
    int status = msgrcv(msgQueue, &msg, MAX_LINESIZE, 5, 0);

    if (status < 0)
        return;

    // printf("-%s-%s-%s-%d-%d-\n", chosenPoems[0], chosenPoems[1], msg.mtext, strcmp(chosenPoems[0], msg.mtext), strcmp(chosenPoems[1], msg.mtext));
    int chosenPoem = strcmp(chosenPoems[0], msg.mtext) == 0 ? chosenLineNums[0] : chosenLineNums[1];
    count = 0;

    rewind(file);

    while ((fgets(msg.mtext, sizeof(msg.mtext), file)) != NULL)
    {
        if (chosenPoem != count++)
            fputs(msg.mtext, temp);
    }

    printf("Nyuszi Mama: Remek! Most gyere haza gyorsan!\n");

    close(fd);
    unlink(pipename);
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
        printf("5 - Locsolas\n");
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
        case 5:
            water();
            break;
        default:
            printf("Nem jo szamot utottel be!\n");
            break;
        }

        printf("\n");
    } while (true);
}
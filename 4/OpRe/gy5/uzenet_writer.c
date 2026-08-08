#include <sys/ipc.h>
#include <sys/msg.h>
#include <sys/types.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <wait.h>
#include <errno.h>

struct Message
{
     long mtype; // ez egy szabadon hasznalhato ertek, pl uzenetek osztalyozasara
     int endIndex;
     char mtext[1024];
};

int main(int argc, char *argv[])
{
    struct Message m;

    key_t kulcs = ftok(argv[0], 123);
    int uzenetsor, status;

    char readBuf[1024];
    char *line = readBuf;
    size_t len, lineSize;

    while (1)
    {
        lineSize = getline(&line, &len, stdin);

        const struct Message m = { 6, lineSize, *line };

        uzenetsor = msgget( kulcs, 0666 | IPC_CREAT );
        status = msgsnd(uzenetsor, &m, m.endIndex, 0); 

    }

    return 0;
}
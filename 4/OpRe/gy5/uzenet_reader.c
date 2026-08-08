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

int isRunning = 1;

void intHandler(int signumber)
{
    printf("Interrupting...\n");
    isRunning = 0;
}

int main(int argc, char *argv[])
{
    signal(SIGINT, intHandler);

    key_t key = ftok(argv[0], 123);
    int mqueue = msgget(key, 0600 | IPC_CREAT);
    if (mqueue < 0)
    {
        perror("msgget");
        return 1;
    }
    else printf("MQ created, Key: %i\n", key);

    struct Message message;
    while (isRunning)
    {
        sleep(1);
        if (msgrcv(mqueue, &message, sizeof(struct Message) - sizeof(long), 0, IPC_NOWAIT | MSG_NOERROR) < 0)
        {
            if (errno != ENOMSG)
            {
                perror("msgrcv");
                isRunning = 0;
            }
        }
        else
        {
            if (message.endIndex < 0)
            {
                printf("Message received, endIndex (%i) is negative.\n", message.endIndex);
                continue;
            }
            if (message.endIndex >= sizeof(message.mtext))
            {
                printf("Message received, endIndex (%i) is too large.\n", message.endIndex);
                continue;
            }
            if (message.mtext[message.endIndex] != '\0')
            {
                printf("Message received, endIndex (%i) element is not null (%c).\n", message.endIndex, message.mtext[message.endIndex]);
                continue;
            }

            printf("Message Received: %s\n", message.mtext);
        }
    }

    if (msgctl(mqueue, IPC_RMID, NULL) < 0)
        perror("msgctl");
    else printf("MQ removed\n");

    return 0;
}

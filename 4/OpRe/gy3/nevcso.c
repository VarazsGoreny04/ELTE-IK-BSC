#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <errno.h> // for errno, the number of last error

int main(int argc, char *argv[])
{
    int pid, fd;
    printf("Fifo start!\n");
    char pipename[20];
    // In most of system not required full path,
    // enough a simple name, eg. alma.fa
    // In Debian must define full path name,
    // so best place is in Debian the /tmp dir.
    sprintf(pipename, "/tmp/%d", getpid());
    int fid = mkfifo(pipename, S_IRUSR | S_IWUSR); // creating named pipe file
    // S_IWGRP, S_IROTH (other jog), file permission mode
    // the file name: fifo.ftc
    // the real fifo.ftc permission is: mode & ~umask
    if (fid == -1)
    {
        printf("Error number: %i", errno);
        perror("Gaz van:");
        exit(EXIT_FAILURE);
    }
    printf("Mkfifo vege, fork indul!\n");
    pid = fork();

    if (pid > 0) // parent
    {
        printf("Szulo\n");

        char s[1024] = "Semmi";

        fd = open(pipename, O_RDONLY);

        do
        {
            read(fd, s, sizeof(s));
            printf("Szulo - olvas: %s \n", s);
        } while (strcmp(s, "vege\n"));

        close(fd);
        // remove fifo.ftc
        unlink(pipename);
        printf("Szulo vege!");
    }
    else // child
    {
        printf("Gyerek\n");

        char *line = NULL;
        size_t len, lineSize;

        fd = open(pipename, O_WRONLY);

        do
        {
            lineSize = getline(&line, &len, stdin);
            printf("Gyerek - kuldi: %s", line);
            write(fd, line, 12);
        } while (strcmp(line, "vege\n"));

        close(fd);
        printf("Gyerek vege!\n");
    }

    return 0;
}

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h> // for pipe()
#include <string.h>
#include <sys/wait.h>
#include <time.h>
//
// unnamed pipe example
//
int main(int argc, char *argv[])
{
    int pipefd[2]; // unnamed pipe file descriptor array
    pid_t pid;
    char sz[100];  // char array for reading from pipe

    if (pipe(pipefd) == -1) 
    {
        perror("Hiba a pipe nyitaskor!");
        exit(EXIT_FAILURE);
    }
    pid = fork();	// creating parent-child processes
    if (pid == -1) 
    {
        perror("Fork hiba");
        exit(EXIT_FAILURE);
    }

    if (pid == 0) // Child process
    {
        sleep(2);	// Not necessary
        close(pipefd[1]);  //Usually we close the unused write end

        printf("Gyerek elkezdi olvasni a csobol az adatokat!\n");

        int c, i = 1;

        do
        {
            read(pipefd[0], &c, sizeof(int));
            printf("Gyerek:        | %i. - %i\n", i, c);
            ++i;
            sleep(1);
        } while (c != 0);
        

        printf("Gyerek befejezte az olvasast!\n");

        close(pipefd[0]); // finally we close the used read end
    }
    else // Szulo process
    {
        printf("Szulo elindul!\n");
        close(pipefd[0]); //Usually we close unused read end

        int r, i = 1;

        do
        {
            srand(time(NULL));
            r = rand() % 10;
            write(pipefd[1], &r, sizeof(int));
            printf("Szulo: %i. - %i\n", i, r);
            ++i;
            sleep(1);
        } while (r != 0);
        
        close(pipefd[1]); // Closing write descriptor
        printf("Szulo beirta az adatokat a csobe!\n");

        fflush(NULL); 	// flushes all write buffers (not necessary)
        wait(NULL);		// waiting for child process (try it without wait() xd)

        printf("Szulo befejezte!\n");	
    }
    exit(EXIT_SUCCESS);	// force exit, not necessary
}
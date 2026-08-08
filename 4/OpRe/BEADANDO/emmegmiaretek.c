#include <stdio.h>
#include <signal.h>
#include <unistd.h>
#include <sys/wait.h>

void handler(int signumber)
{
    printf("*Titkos uzenet szall a szellel* (%d)\n", signumber);
}

int main()
{
    struct sigaction new_sigaction;
    new_sigaction.sa_handler = handler;
    sigemptyset(&new_sigaction.sa_mask);
    new_sigaction.sa_flags = 0;
    sigaction(SIGINT, &new_sigaction, NULL);
    sigaction(SIGUSR1, &new_sigaction, NULL);

    sigset_t new_sigset;
    sigfillset(&new_sigset);
    sigdelset(&new_sigset, SIGUSR1);
    sigdelset(&new_sigset, SIGINT);

    int c = 1, pidP = getppid(), pidC = fork();

    if (pidC > 0) // parent
    {
        printf("Parent1: %d\n", c++);

        sigsuspend(&new_sigset);

        printf("Parent2: %d\n", c++);

        sleep(3);
        kill(pidC, SIGUSR1);

        printf("Parent3: %d\n", c++);

        sigsuspend(&new_sigset);

        printf("Parent4: %d\n", c++);

        int status;
        wait(&status);
    }
    else
    {
        printf("Child1: %d\n", c++);

        sleep(3);
        kill(pidP, SIGUSR1);

        printf("Child2: %d\n", c++);

        sigsuspend(&new_sigset);

        printf("Child3: %d\n", c++);

        sleep(3);
        kill(pidP, SIGUSR1);

        printf("Child4: %d\n", c++);

        _exit(0);
    }
}
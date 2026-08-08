#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>  //fork
#include <sys/wait.h> //waitpid
#include <errno.h> 

int main()
{
    int status;
    int notacommonvalue = 1;

    printf("The value is %i before forking \n",notacommonvalue);

    pid_t child = fork(); //forks make a copy of variables

    if (child < 0)
    {
        perror("The 1. fork calling was not succesful\n");
        exit(1);
    }

    if (child > 0) //the parent process, it can see the returning value of fork - the child variable!
    {
        int status2;
        waitpid(child, &status, 0);
        pid_t child2 = fork();

        if (child2 < 0)
        {
            perror("The 2. fork calling was not succesful\n");
            exit(1);
        }

        if (child2 > 0)
        {
            waitpid(child2, &status2, 0);
            printf("The value is %i in parent process (remain the original) \n", notacommonvalue);
        }
        else
        {
            notacommonvalue = 10; //it changes the value of the copy of the variable
            printf("The value is %i in child2 process \n", notacommonvalue);
        }
    }
    else //child process
    {
        notacommonvalue = 5; //it changes the value of the copy of the variable
        printf("The value is %i in child process \n", notacommonvalue);
    }

    return 0;
}
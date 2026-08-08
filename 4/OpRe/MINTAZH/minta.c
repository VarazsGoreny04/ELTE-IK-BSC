#include <stdio.h>

#define PREXPIPE "/tmp/prex"
#define EXSEPIPE "/tmp/exse"
#define IDENTIFIER 10 

sigset_t new_sigset;
struct sigaction new_sigaction;

struct Voter
{
	char *name;
	char *identifier;
};

void handler(int signumber)
{
	printf("*Titkos uzenet szall a szellel* (%d)\n", signumber);
}

void president(int count, char** data)
{
	int fid = mkfifo(PREXPIPE, S_IRUSR | S_IWUSR);
	if (fid < 0)
	{
		printf("Hiba tortent a cso megnyitasakor!\n");
		exit(0);
	}

	int pid = fork();

	if (pid == 0)
	{
		examiner(count)
	}

	struct Voter voters[count];
	int fd = open(PREXPIPE, O_WRONLY);
	srand(time(NULL));
	char *buff[IDENTIFIER];

	for (int i = 0; i < count; ++i)
	{
		sprintf(buff, "%d", rand() % 2 + (i * 2));
		voters[i] = {data[i], buff}
		write(fd, buff, strlen(buff));
		write(fd, "\n", 1);
	}

	kill(pid, SIGUSR1);
	sigsuspend(&new_sigset);

	exit(0);
}

void examiner(int count)
{
	int fid = mkfifo(PREXPIPE, S_IRUSR | S_IWUSR);
	if (fid < 0)
	{
		printf("Hiba tortent a cso megnyitasakor!\n");
		exit(0);
	}

	int pid = fork();

	if (pid == 0)
	{
		secretary(getppid())
	}

	int fd = open(PREXPIPE, O_RDONLY);

	sigsuspend(&new_sigset);

	char buff[IDENTIFIER * count];
	read(fd, buff, sizeof(buff))
	char* oneId = strtok(buff, "\n");

	if (oneId != NULL)
		printf("%s\n", oneId);

	while(oneId = strtok(NULL, "\n") != NULL)
		printf("%s\n", oneId);

	kill(pid, SIGUSR1);
	kill(getppid(), SIGUSR1);

	exit(0);
}

void secretary(int presPid)
{
	int fid = mkfifo(EXSEPIPE, S_IRUSR | S_IWUSR);
	if (fid < 0)
	{
		printf("Hiba tortent a cso megnyitasakor!\n");
		exit(0);
	}

	sigsuspend(&new_sigset);

	exit(0);
}

int main(int argc, char** argv)
{
	sigfillset(&new_sigset);
	sigdelset(&new_sigset, SIGINT);
	sigdelset(&new_sigset, SIGTERM);
	sigprocmask(SIG_BLOCK, &new_sigset, NULL);
	sigdelset(&new_sigset, SIGUSR1);
	sigdelset(&new_sigset, SIGUSR2);

	new_sigaction.sa_handler = handler;
	sigemptyset(&new_sigaction.sa_mask);
	new_sigaction.sa_flags = 0;
	sigaction(SIGINT, &new_sigaction, NULL);
	sigaction(SIGUSR1, &new_sigaction, NULL);
	sigaction(SIGUSR2, &new_sigaction, NULL);

	president(argc, argc);
}
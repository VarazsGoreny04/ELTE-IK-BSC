#include <stdio.h>

int main()
{
	//Celsius -> Fahrenheit
	for (double i = -20.0; i <= 200.0; i += 10.0)
	{
		printf("%.2lf\n", (i - 32.0) / 1.8);
	}
	printf("\n\"Hello\" \"world\"\n");

	//Osszes oszto
	int szam = 8;
	printf("Adj meg egy szamot: ");
	scanf_s("%d\n", &szam);
	for (int i = szam; i > 0; i--)
	{
		if (szam % i == 0)
			printf(i);
	}

	//Legkisebb kozos tobbszoros:
	int szamlalo, egyszam = 0, ketszam = 0;
	if (egyszam >= ketszam)
		szamlalo = egyszam;
	else
		szamlalo = ketszam;
	printf("Adj meg egy szamot: ");
	scanf_s("%d\n", &egyszam);
	printf("Adj meg meg egy szamot: ");
	scanf_s("%d\n", &ketszam);
	do
	{
		szamlalo++;
	} while (szamlalo % egyszam == 0 && szamlalo % ketszam == 0);
	printf("A ket szam legkisebb kozos tobbszorose %d\n", szamlalo);

	//
}
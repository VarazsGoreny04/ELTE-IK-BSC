#include <stdio.h>
#include <math.h>
int main()
{
	int a, b, years;
	double c, d, e, fok;
	char name[] = "Trefi[man Viktor]";
	printf("Szia! Az en nevem %s. En vagyok a program keszitoje.\n\n", name);

	printf("Add meg a negyszog egyik oldalat: ");
	scanf_s("%d", &a);
	printf("Add meg a negyszog masik oldalat: ");
	scanf_s("%d", &b);
	printf("Most pedig add meg a kor sugarat: ");
	scanf_s("%lf", &c);
	printf("A negyzet kerulete %d\nA terulete pedig: %d\nA kor kerulete: %lf\n A terulete pedig: %lf", 2 * (a + b), a * b, 2 * c * 3.1415, pow(c, 2) * 3.1415);

	printf("\n\nAdj meg egy szamot: ");
	scanf_s("%lf", &d);
	printf(/*Ha az oszto 0 akkor az eredmeny ennyi: %d\n*/"Adj meg meg egy szamot : "/*, a / 0*/);
	scanf_s("%lf", &e);
	printf("Ha elosztjuk a ket szamot ennyi az eredmeny: %lf\n\n", d / e);

	printf("Add meg a napok szamat: ");
	scanf_s("%d", &years);
	int weeks = years % 365;
	printf("A beirt napok %d evnek %d hetnek es %d napnak felelnek meg\n\n", years / 365, weeks / 7, weeks % 7);

	printf("Add meg a homersekletet Celsiusban: ");
	scanf_s("%lf", &fok);
	printf("A homerseklet Fahrenheitben: %.2lf (Mondom en, hulyek ezek!)", fok * 1.8000 + 32);
	return 0;
}
namespace Rally;

public class Eredmenylap(Csapat c, Futam f, Kategoria kat)
{
	private readonly Csapat csapat = c;
	private readonly Futam futam = f;
	private readonly Kategoria eredmeny = kat;

	public Csapat Csapat => csapat;
	public Futam Futam => futam;
	public Kategoria Eredmeny => eredmeny;

	public void Rogzit(int hely)
	{
		eredmeny.Hely = hely;
	}

	public int Ertek()
	{
		return futam.Lapok.FindAll(x => x.csapat.Azon == csapat.Azon).Sum(x => x.Eredmeny.Pont(futam.Lapok.Count));
	}
}
namespace Rally;

public class Futam(DateTime fi, Verseny verseny)
{
	private readonly DateTime indul = fi;
	private readonly Verseny verseny = verseny;
	private readonly List<Eredmenylap> lapok = [];

	public DateTime Indul => indul;
	public Verseny Verseny => verseny;
	public List<Eredmenylap> Lapok => lapok;

	private (bool, Eredmenylap?) KeresLap(Csapat c)
	{
		Eredmenylap? e = lapok.Find(x => x.Csapat.Azon == c.Azon);
		return (e is not null, e);
	}

	public void Nevez(Csapat c, Kategoria k)
	{
		if (!verseny.Csapatok.Any(x => x.Azon == c.Azon) || KeresLap(c).Item1)
			throw new Exception();

		Eredmenylap lap = new(c, this, k);

		lapok.Add(lap);
		c.Lapok.Add(lap);
	}
}
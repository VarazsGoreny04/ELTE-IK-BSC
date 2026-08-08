namespace Rally;

public class Verseny
{
	private readonly List<Futam> futamok;
	private readonly List<Csapat> csapatok;
	private readonly DateOnly datum;
	private readonly string helyszin;

	public List<Futam> Futamok => futamok;
	public List<Csapat> Csapatok => csapatok;
	public DateOnly Datum => datum;
	public string Helyszin => helyszin;

	public Verseny(DateOnly d, string h, DateTime[] futido)
	{
		datum = d;
		helyszin = h;

		futamok = [];
		foreach (DateTime fi in futido)
			futamok.Add(new Futam(fi, this));

		csapatok = [];
	}

	public void Regisztral(Csapat t)
	{
		if (csapatok.Any(x => x.Azon == t.Azon))
			throw new Exception();

		Random rnd = new();
		t.Azon = rnd.Next(100, 1000).ToString();
		csapatok.Add(t);
	}

	public string Nyertes()
	{
		Csapat? c = csapatok.MaxBy(x => x.Teljesitmeny());

		if (c is not null)
			return c.Azon;
		else
			throw new Exception();
	}
}
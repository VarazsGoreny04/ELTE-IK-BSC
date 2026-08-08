namespace Covid;

public class Oltohely(string hely)
{
	private readonly DateOnly maiDatum = new(2024, 04, 10);

	private readonly string hely = hely;
	private readonly List<Paciens> regisztraltak = [];
	private readonly List<Vakcina> vakcinak = [];

	public string Hely => hely;

	public void Beszerez(Vakcina v)
	{
		vakcinak.Add(v);
	}

	public void Regisztral(Paciens p)
	{
		if (regisztraltak.Any(x => x.Taj == p.Taj))
			throw new Exception();

		regisztraltak.Add(p);
	}

	public void Beolt(Paciens p, string n)
	{
		Vakcina? vakcina = vakcinak.Find(x => x.Nev() == n && x.Lejar > maiDatum);
		Paciens? paciens = regisztraltak.Find(x => x.Taj ==  p.Taj);

		if (vakcina is not null && paciens is not null)
		{
			vakcinak.Remove(vakcina);
			Oltas o = new(maiDatum, vakcina);
			paciens.AddOltas(o);
		}
	}

	public int HanyanKettot()
	{
		return regisztraltak.Count(x => x.HanyOltas() >= 2);
	}
}
namespace Bevasarlas;

public class Vasarlo
{
	private readonly List<string> bevasarloLista;
	public List<Termek> kosar;

	public List<string> BevasarloLista => bevasarloLista;

	public Vasarlo(List<string> bevasarloLista)
	{
		this.bevasarloLista = bevasarloLista;
		kosar = [];
	}

	public void Vasarol(Uzlet s)
	{
		List<string> masolat = [.. bevasarloLista];

		foreach (string nev in masolat)
		{
			Termek? termek = Keres(nev, s.Elelmiszer);

			if (termek is not null)
			{
				Vesz(termek, s.Elelmiszer);
				bevasarloLista.Remove(nev);
			}
		}

		foreach (string nev in masolat)
		{
			Termek? termek = OlcsotKeres(nev, s.Muszaki);

			if (termek is not null)
			{
				Vesz(termek, s.Muszaki);
				bevasarloLista.Remove(nev);
			}
		}
	}

	private static Termek? Keres(string nev, Reszleg r)
	{
		return r.Keszlet.Find(e => nev == e.Nev);

		/*foreach (Termek termek in r.Keszlet)
		{
			if (termek.Nev == nev)
				return termek;
		}

		return null;*/
	}

	private static Termek? OlcsotKeres(string nev, Reszleg r)
	{
		List<Termek> termekek = r.Keszlet.FindAll(e => nev == e.Nev);

		return termekek.MinBy(t => t.Ar);

		/*int minVal = int.MaxValue;
		int minInd = -1;

		for (int i = 0; i < r.Keszlet.Count; ++i)
		{
			if (r.Keszlet[i].Nev == nev && minVal > r.Keszlet[i].Ar)
			{
				minVal = r.Keszlet[i].Ar;
				minInd = i;
			}
		}

		return minInd < 0 ? null : r.Keszlet[minInd];*/
	}

	private void Vesz(Termek term, Reszleg r)
	{
		bool check = r.Keszlet.Remove(term);

		/*if (!check)
			throw new Exception();*/

		kosar.Add(term);
	}
}
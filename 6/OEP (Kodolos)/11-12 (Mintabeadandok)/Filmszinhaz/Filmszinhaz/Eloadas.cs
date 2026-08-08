namespace Filmszinhaz;

public enum Allapot
{
	SZABAD,
	FOGLALT,
	ELADOTT
}

public class NemLegalisUlesallapotException : Exception { }
public class NemFoglaltException : Exception { }
public class NemUresException : Exception { }

public class Eloadas
{
	public readonly string filmcim;
	public readonly Ido ido;
	public int maxHely;
	public List<Foglalas> FoglaltHelyek { get; private set; }

	public Eloadas(string cim, Ido ido)
	{
		filmcim = cim;
		this.ido = ido;
		FoglaltHelyek = [];
	}

	public int[] HelyekSzama()
	{
		return [maxHely, FoglaltHelyek.Count(x => x.allapot == Allapot.FOGLALT), FoglaltHelyek.Count(x => x.allapot == Allapot.ELADOTT)];
	}

	public Foglalas ValosFoglalas(Foglalas foglalas)
	{
		Foglalas? keresett = FoglaltHelyek.Find(x => x == foglalas && x.allapot == Allapot.FOGLALT);
		return keresett ?? throw new NemFoglaltException();
	}

	public static void Szabadda(ref Allapot a)
	{
		if (a == Allapot.FOGLALT)
			a = Allapot.SZABAD;
		else
			throw new NemLegalisUlesallapotException();
	}

	public static void Foglaltta(ref Allapot a)
	{
		if (a == Allapot.SZABAD)
			a = Allapot.FOGLALT;
		else
			throw new NemLegalisUlesallapotException();
	}

	public static void Eladotta(ref Allapot a)
	{
		if (a == Allapot.FOGLALT)
			a = Allapot.ELADOTT;
		else
			throw new NemLegalisUlesallapotException();
	}

	public void FoglalttaAllitas(Foglalas foglalas)
	{
		if (FoglaltHelyek.Any(x => x.ules == foglalas.ules))
			throw new NemUresException();
		else
		{
			FoglaltHelyek.Add(foglalas);
			Foglaltta(ref foglalas.allapot);
		}
	}

	public void EladottaAllitas(Foglalas foglalas)
	{
		Foglalas f = ValosFoglalas(foglalas);
		Eladotta(ref f.allapot);
	}

	public void SzabaddaAllitas(Foglalas foglalas)
	{

		Foglalas f = ValosFoglalas(foglalas);
		Szabadda(ref f.allapot);
		FoglaltHelyek.Remove(f);
	}
}
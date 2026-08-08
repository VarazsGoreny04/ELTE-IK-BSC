namespace Kert;

public class Kert
{
	private readonly Parcella[] parcellak;

	public Kert(int parcellaSzam)
	{
		parcellak = new Parcella[parcellaSzam];

		for (int i = 0; i < parcellak.Length; ++i)
			parcellak[i] = new Parcella();
	}

	public void Ultet(int hova, Novenyfajta mit)
	{
		parcellak[hova].Ultet(mit);
	}

	public void Leszed(int hol)
	{
		parcellak[hol].Leszed();
	}

	public List<int> Szedheto(int honap)
	{
		List<int> indexek = [];

		for (int i = 0; i < parcellak.Length; ++i)
		{
			if (parcellak[i].Beerik(honap))
				indexek.Add(i);
		}

		return indexek;
	}
}
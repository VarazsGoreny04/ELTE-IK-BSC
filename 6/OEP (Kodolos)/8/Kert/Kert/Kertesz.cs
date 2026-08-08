namespace Kert;

public class Kertesz
{
	public Kert kert;

	public Kertesz()
	{
		kert = new Kert(6);
	}

	public static int JelenHonap()
	{
		return 5;

		Random rnd = new();

		return rnd.Next(1, 13);
	}
}
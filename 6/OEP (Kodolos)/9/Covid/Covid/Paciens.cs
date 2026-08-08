namespace Covid;

public class Paciens(string taj)
{
	private readonly string taj = taj;
	private readonly List<Oltas> oltasok = [];

	public string Taj => taj;

	public int HanyOltas()
	{
		return oltasok.Count;
	}

	public void AddOltas(Oltas o)
	{
		oltasok.Add(o);
	}
}
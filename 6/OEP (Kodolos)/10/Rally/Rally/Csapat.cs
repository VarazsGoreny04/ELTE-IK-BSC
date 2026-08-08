namespace Rally;

public class Csapat(string azon)
{
	private readonly List<Eredmenylap> lapok = [];
	private string azon = azon;

	public string Azon { get => azon; set => azon = value; }
	public List<Eredmenylap> Lapok => lapok;

	public int Teljesitmeny()
	{
		return lapok.Sum(x => x.Ertek());
	}
}
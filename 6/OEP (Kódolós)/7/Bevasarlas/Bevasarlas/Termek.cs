namespace Bevasarlas;

public class Termek
{
	private readonly string nev;
	private readonly int ar;

	public string Nev => nev;
	public int Ar => ar;

	public Termek(string nev, int ar)
	{
		this.nev = nev;
		this.ar = ar;
	}
}
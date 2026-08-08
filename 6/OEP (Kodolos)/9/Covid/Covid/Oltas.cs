namespace Covid;

public class Oltas(DateOnly datum, Vakcina vakcina)
{
	private readonly DateOnly datum = datum;
	private readonly Vakcina vakcina = vakcina;

	public DateOnly Datum => datum;
	public Vakcina Vakcina => vakcina;
}
namespace Covid;

internal class Program
{
	static void Main()
	{
		Console.WriteLine("Járvány van. Maradj otthon!");

		Vakcina v = new Astrazeneca(DateOnly.MaxValue);

		Console.WriteLine(v.Nev());
	}
}
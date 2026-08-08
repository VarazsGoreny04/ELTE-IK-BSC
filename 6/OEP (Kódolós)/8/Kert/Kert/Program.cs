namespace Kert;

internal class Program
{
    static void Main()
	{
		Kertesz kertesz = new();

		kertesz.kert.Ultet(1, Burgonya.Instantiate());
		kertesz.kert.Ultet(2, Borso.Instantiate());
		kertesz.kert.Ultet(4, Borso.Instantiate());

		Console.Write("A betakarithato parcellak azonositoi: ");
		foreach (int i in kertesz.kert.Szedheto(7))
			Console.Write($"{i} ");
		Console.WriteLine();
	}
}
namespace Bevasarlas;

internal class Program
{
    static void Main(string[] args)
    {
        Vasarlo v1 = new(Olvas.TermekNevek("bevL1.txt"));
        Vasarlo v2 = new(Olvas.TermekNevek("bevL2.txt"));

		Reszleg elelmiszer = new();
		Reszleg muszaki = new();

        elelmiszer.Keszlet = Olvas.Termekek("e.txt");
        muszaki.Keszlet = Olvas.Termekek("m.txt");

        Uzlet tacsko = new(elelmiszer, muszaki);

        v1.Vasarol(tacsko);
        v2.Vasarol(tacsko);

		Console.WriteLine("Tacskoban maradt:");
		foreach (Termek termek in tacsko.Elelmiszer.Keszlet)
			Console.WriteLine($"{termek.Nev} : {termek.Ar}");
		Console.WriteLine();

		foreach (Termek termek in tacsko.Muszaki.Keszlet)
			Console.WriteLine($"{termek.Nev} : {termek.Ar}");
		Console.WriteLine();

		Console.WriteLine("v1 mit nem talált:");
		foreach (string termek in v1.BevasarloLista)
			Console.WriteLine(termek);
		Console.WriteLine();

		Console.WriteLine("v2 mit nem talált:");
		foreach (string termek in v2.BevasarloLista)
			Console.WriteLine(termek);
	}
}
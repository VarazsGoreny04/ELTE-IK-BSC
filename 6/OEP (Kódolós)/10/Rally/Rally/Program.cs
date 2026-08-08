namespace Rally;

internal class Program
{
	static void Main()
	{
		Console.WriteLine("Megy a Dakar, mit mindenki nézni akar :)");

		DateTime[] futamok =
		[
			new DateTime(2025, 1, 3),
			new DateTime(2025, 1, 4),
			new DateTime(2025, 1, 7),
			new DateTime(2025, 1, 10),
			new DateTime(2025, 1, 15)
		];

		Verseny dakarRally = new(new DateOnly(2025, 1, 3), "Szaúd-Arábia", futamok);

		Csapat alpha = new("Alpha");
		Csapat beta = new("Beta");
		Csapat gamma = new("Gamma");

		dakarRally.Regisztral(alpha);
		dakarRally.Regisztral(beta);
		dakarRally.Regisztral(gamma);

		Futam first = new(new DateTime(2025, 1, 3), dakarRally);
		Futam second = new(new DateTime(2025, 1, 4), dakarRally);
		Futam third = new(new DateTime(2025, 1, 7), dakarRally);

		dakarRally.Futamok.Add(first);
		dakarRally.Futamok.Add(second);
		dakarRally.Futamok.Add(third);

		first.Nevez(alpha, new Sport());
		first.Nevez(beta, new Motor());
		first.Nevez(gamma, new Teher());

		Console.Write("Jó - ");
		try
		{
			first.Nevez(alpha, new Teher());
			Console.WriteLine("Rossz");
		}
		catch (Exception)
		{
			Console.WriteLine("Jó");
		}

		Console.WriteLine($"{gamma.Azon} - {dakarRally.Nyertes()}");

		second.Nevez(alpha, new Teher());

		Console.Write("Jó - ");
		try
		{
			second.Nevez(alpha, new Teher());
			Console.WriteLine("Rossz");
		}
		catch (Exception)
		{
			Console.WriteLine("Jó");
		}

		Console.WriteLine($"{alpha.Azon} - {dakarRally.Nyertes()}");

		third.Nevez(beta, new Motor());
		third.Nevez(gamma, new Teher());

		Console.WriteLine($"{gamma.Azon} - {dakarRally.Nyertes()}");
	}
}